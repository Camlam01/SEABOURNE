using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using System.Reflection;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Cards;

[Pool(typeof(SEABOURNECardPool))]
public abstract class SeabourneCard : CustomCardModel
{
    private static readonly string[] BaseCostMemberNames = ["BaseCost", "CardBaseCost", "DefaultCost", "PrintedCost"];
    private static readonly string[] CurrentCostMemberNames = ["Cost", "CurrentCost", "CostForTurn", "TurnCost", "DisplayedCost", "ModifiedCost", "EnergyCost"];
    private static readonly string[] CostFlagNames = ["IsCostModified", "CostModified", "HasModifiedCost"];

    private int _baseSeabourneCost;
    private int _currentSeabourneCost;

    public virtual bool HasAttackDamage => false;
    public virtual bool HasBuffOrDebuffStacks => false;
    public virtual bool HasCastOrReel => false;
    public virtual bool CanReceiveWet => true;

    public decimal GemDamageMultiplier { get; set; } = 1m;
    public int GemStackBonus { get; set; }
    public int GemCostReduction { get; set; }
    public int GemAddedCast { get; set; }
    public int GemAddedReel { get; set; }
    public int GemAddedWet { get; set; }
    public bool GemShouldExhaust { get; set; }

    protected int SeabourneCost
    {
        get => _baseSeabourneCost;
        set
        {
            var normalizedCost = NormalizeCost(value);
            _baseSeabourneCost = normalizedCost;
            _currentSeabourneCost = normalizedCost;
            SyncCostToModel();
        }
    }

    protected int CurrentSeabourneCost => _currentSeabourneCost;

    protected bool IsSeabourneUpgraded => GetUpgradeState();

    protected SeabourneCard(int cost, CardType type, CardRarity rarity, TargetType targetType)
        : base(cost, type, rarity, targetType)
    {
        _baseSeabourneCost = NormalizeCost(cost);
        _currentSeabourneCost = _baseSeabourneCost;
        SyncCostToModel();
    }

    public override string PortraitPath => "res://SEABOURNE/images/card_placeholder.png";
    public override string BetaPortraitPath => PortraitPath;

    protected async Task ApplySeabourneGemModifiers()
    {
        ResetGemRuntimeModifiers();
        await SeabourneGemSystem.ApplyGemModifiers(this);
        await SeabourneGemSystem.ApplyRuntimePlayEffects(this);

        if (GemCostReduction > 0)
            ReduceCurrentCostBy(GemCostReduction);
    }

    protected void SetBaseCost(int cost) => SeabourneCost = cost;

    protected void ReduceBaseCostBy(int amount) =>
        SeabourneCost = NormalizeCost(_baseSeabourneCost - Math.Max(0, amount));

    protected void SetCurrentCost(int cost)
    {
        _currentSeabourneCost = NormalizeCost(cost);
        SyncCostToModel();
    }

    protected void ReduceCurrentCostBy(int amount)
    {
        _currentSeabourneCost = NormalizeCost(_currentSeabourneCost - Math.Max(0, amount));
        SyncCostToModel();
    }

    protected void ResetCurrentCost()
    {
        _currentSeabourneCost = _baseSeabourneCost;
        SyncCostToModel();
    }

    protected decimal ModifyGemDamage(decimal baseDamage) => Math.Ceiling(baseDamage * GemDamageMultiplier);

    public decimal ModifyExternalGemDamage(decimal baseDamage) => ModifyGemDamage(baseDamage);

    protected int ModifyGemStacks(int baseStacks) => Math.Max(0, baseStacks + GemStackBonus);

    protected int ModifyGemCast(int baseCast) => Math.Max(0, baseCast + GemAddedCast);

    protected int ModifyGemReel(int baseReel) => Math.Max(0, baseReel + GemAddedReel);

    protected async Task ApplyGemWetIfAny()
    {
        if (GemAddedWet > 0)
            await SeabornePowerTools.ApplyPowerToPlayer(WetCardPower.Id, GemAddedWet);
    }

    private void ResetGemRuntimeModifiers()
    {
        GemDamageMultiplier = 1m;
        GemStackBonus = 0;
        GemCostReduction = 0;
        GemAddedCast = 0;
        GemAddedReel = 0;
        GemAddedWet = 0;
        GemShouldExhaust = false;
        ResetCurrentCost();
    }

    private void SyncCostToModel()
    {
        foreach (var memberName in BaseCostMemberNames)
            TrySetNumericMember(memberName, _baseSeabourneCost);

        foreach (var memberName in CurrentCostMemberNames)
            TrySetNumericMember(memberName, _currentSeabourneCost);

        var costIsModified = _currentSeabourneCost != _baseSeabourneCost;
        foreach (var memberName in CostFlagNames)
            TrySetBooleanMember(memberName, costIsModified);
    }

    private void TrySetNumericMember(string memberName, int value)
    {
        foreach (Type type in GetTypeHierarchy())
        {
            var property = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property is { CanWrite: true } && TrySetNumericProperty(property, value))
                return;

            var field = type.GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field is not null && TrySetNumericField(field, value))
                return;
        }
    }

    private void TrySetBooleanMember(string memberName, bool value)
    {
        foreach (Type type in GetTypeHierarchy())
        {
            var property = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property is { CanWrite: true } && property.PropertyType == typeof(bool))
            {
                try
                {
                    property.SetValue(this, value);
                    return;
                }
                catch
                {
                }
            }

            var field = type.GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field?.FieldType == typeof(bool))
            {
                try
                {
                    field.SetValue(this, value);
                    return;
                }
                catch
                {
                }
            }
        }
    }

    private bool TrySetNumericProperty(PropertyInfo property, int value)
    {
        try
        {
            if (property.PropertyType == typeof(int))
            {
                property.SetValue(this, value);
                return true;
            }

            if (property.PropertyType == typeof(int?))
            {
                property.SetValue(this, (int?)value);
                return true;
            }

            if (property.PropertyType == typeof(decimal))
            {
                property.SetValue(this, Convert.ToDecimal(value));
                return true;
            }

            if (property.PropertyType == typeof(decimal?))
            {
                property.SetValue(this, (decimal?)Convert.ToDecimal(value));
                return true;
            }
        }
        catch
        {
        }

        return false;
    }

    private bool TrySetNumericField(FieldInfo field, int value)
    {
        try
        {
            if (field.FieldType == typeof(int))
            {
                field.SetValue(this, value);
                return true;
            }

            if (field.FieldType == typeof(int?))
            {
                field.SetValue(this, (int?)value);
                return true;
            }

            if (field.FieldType == typeof(decimal))
            {
                field.SetValue(this, Convert.ToDecimal(value));
                return true;
            }

            if (field.FieldType == typeof(decimal?))
            {
                field.SetValue(this, (decimal?)Convert.ToDecimal(value));
                return true;
            }
        }
        catch
        {
        }

        return false;
    }

    private IEnumerable<Type> GetTypeHierarchy()
    {
        for (Type? type = GetType(); type is not null; type = type.BaseType)
            yield return type;
    }

    private bool GetUpgradeState()
    {
        object self = this;
        foreach (var name in new[] { "IsUpgraded", "UpgradedCount", "UpgradeCount", "TimesUpgraded" })
        {
            var property =
                self.GetType().BaseType?.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) ??
                self.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            var value = property?.GetValue(self);
            if (value is bool flag)
                return flag;
            if (value is int count)
                return count > 0;
        }

        return false;
    }

    private static int NormalizeCost(int cost) => Math.Max(-1, cost);

    protected static IEnumerable<DamageVar> DamageVar(decimal amount) => [new DamageVar(amount, ValueProp.Move)];
    protected static IEnumerable<BlockVar> BlockVar(decimal amount) => [new BlockVar(amount, ValueProp.Move)];
}
