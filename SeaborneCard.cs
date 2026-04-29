using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using System.Reflection;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

[Pool(typeof(SEABOURNECardPool))]
public abstract class SeaborneCard : CustomCardModel
{
    private static readonly string[] BaseCostMemberNames =
    [
        "BaseCost",
        "CardBaseCost",
        "DefaultCost",
        "PrintedCost"
    ];

    private static readonly string[] CurrentCostMemberNames =
    [
        "Cost",
        "CurrentCost",
        "CostForTurn",
        "TurnCost",
        "DisplayedCost",
        "ModifiedCost",
        "EnergyCost"
    ];

    private static readonly string[] CostFlagNames =
    [
        "IsCostModified",
        "CostModified",
        "HasModifiedCost"
    ];

    private int _baseSeaborneCost;
    private int _currentSeaborneCost;

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

    protected int SeaborneCost
    {
        get => _baseSeaborneCost;
        set
        {
            int normalizedCost = NormalizeCost(value);
            _baseSeaborneCost = normalizedCost;
            _currentSeaborneCost = normalizedCost;
            SyncCostToModel();
        }
    }

    protected int CurrentSeaborneCost => _currentSeaborneCost;
    protected bool IsSeaborneUpgraded => GetUpgradeState();

    protected SeaborneCard(int cost, CardType type, CardRarity rarity, TargetType targetType)
        : base(cost, type, rarity, targetType)
    {
        _baseSeaborneCost = NormalizeCost(cost);
        _currentSeaborneCost = _baseSeaborneCost;
        SyncCostToModel();
    }

    public override string PortraitPath => "res://SEABOURNE/images/card_placeholder.png";
    public override string BetaPortraitPath => PortraitPath;

    protected async Task ApplySeaborneGemModifiers()
    {
        ResetGemRuntimeModifiers();
        await SeaborneGemSystem.ApplyGemModifiers(this);
        await SeaborneGemSystem.ApplyRuntimePlayEffects(this);

        if (GemCostReduction > 0)
        {
            ReduceCurrentCostBy(GemCostReduction);
        }
    }

    protected void SetBaseCost(int cost)
    {
        SeaborneCost = cost;
    }

    protected void ReduceBaseCostBy(int amount)
    {
        SeaborneCost = NormalizeCost(_baseSeaborneCost - Math.Max(0, amount));
    }

    protected void SetCurrentCost(int cost)
    {
        _currentSeaborneCost = NormalizeCost(cost);
        SyncCostToModel();
    }

    protected void ReduceCurrentCostBy(int amount)
    {
        _currentSeaborneCost = NormalizeCost(_currentSeaborneCost - Math.Max(0, amount));
        SyncCostToModel();
    }

    protected void ResetCurrentCost()
    {
        _currentSeaborneCost = _baseSeaborneCost;
        SyncCostToModel();
    }

    protected decimal ModifyGemDamage(decimal baseDamage)
    {
        return Math.Ceiling(baseDamage * GemDamageMultiplier);
    }

    public decimal ModifyExternalGemDamage(decimal baseDamage)
    {
        return ModifyGemDamage(baseDamage);
    }

    protected int ModifyGemStacks(int baseStacks)
    {
        return Math.Max(0, baseStacks + GemStackBonus);
    }

    protected int ModifyGemCast(int baseCast)
    {
        return Math.Max(0, baseCast + GemAddedCast);
    }

    protected int ModifyGemReel(int baseReel)
    {
        return Math.Max(0, baseReel + GemAddedReel);
    }

    protected async Task ApplyGemWetIfAny()
    {
        if (GemAddedWet > 0)
        {
            await SeabornePowerTools.ApplyPowerToPlayer(WetCardPower.Id, GemAddedWet);
        }
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
        foreach (string memberName in BaseCostMemberNames)
        {
            TrySetNumericMember(memberName, _baseSeaborneCost);
        }

        foreach (string memberName in CurrentCostMemberNames)
        {
            TrySetNumericMember(memberName, _currentSeaborneCost);
        }

        bool costIsModified = _currentSeaborneCost != _baseSeaborneCost;

        foreach (string memberName in CostFlagNames)
        {
            TrySetBooleanMember(memberName, costIsModified);
        }
    }

    private void TrySetNumericMember(string memberName, int value)
    {
        foreach (Type type in GetTypeHierarchy())
        {
            PropertyInfo? property = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property is { CanWrite: true } && TrySetNumericProperty(property, value))
            {
                return;
            }

            FieldInfo? field = type.GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field is not null && TrySetNumericField(field, value))
            {
                return;
            }
        }
    }

    private void TrySetBooleanMember(string memberName, bool value)
    {
        foreach (Type type in GetTypeHierarchy())
        {
            PropertyInfo? property = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
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

            FieldInfo? field = type.GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
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
        {
            yield return type;
        }
    }

    private bool GetUpgradeState()
    {
        object self = this;

        foreach (string name in new[] { "IsUpgraded", "UpgradedCount", "UpgradeCount", "TimesUpgraded" })
        {
            PropertyInfo? property = self.GetType().BaseType?.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                ?? self.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            object? value = property?.GetValue(self);

            if (value is bool flag)
            {
                return flag;
            }

            if (value is int count)
            {
                return count > 0;
            }
        }

        return false;
    }

    private static int NormalizeCost(int cost)
    {
        return Math.Max(-1, cost);
    }

    protected static IEnumerable<DynamicVar> DamageVar(decimal amount)
    {
        return [new DamageVar(amount, ValueProp.Move)];
    }

    protected static IEnumerable<DynamicVar> BlockVar(decimal amount)
    {
        return [new BlockVar(amount, ValueProp.Move)];
    }
}
