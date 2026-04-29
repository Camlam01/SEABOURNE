using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using System.Reflection;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Systems;
using SEABOURNE.SEABOURNECode.Utils;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Cards;

[Pool(typeof(SEABOURNECardPool))]
public abstract class SeaborneCard : CustomCardModel
{

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

    protected int SeaborneCost { get; set; }

    protected bool IsSeaborneUpgraded => GetUpgradeState();

    protected async Task ApplySeaborneGemModifiers()
    {
        ResetGemRuntimeModifiers();
        await SeaborneGemSystem.ApplyGemModifiers(this);
        await SeaborneGemSystem.ApplyRuntimePlayEffects(this);
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
    }

    public override string PortraitPath => "res://SEABOURNE/images/card_placeholder.png";
    public override string BetaPortraitPath => PortraitPath;

    protected SeaborneCard(int cost, CardType type, CardRarity rarity, TargetType targetType)
        : base(cost, type, rarity, targetType)
    {
        SeaborneCost = cost;
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

    protected static IEnumerable<DynamicVar> DamageVar(decimal amount)
    {
        return [new MegaCrit.Sts2.Core.Localization.DynamicVars.DamageVar(amount, ValueProp.Move)];
    }

    protected static IEnumerable<DynamicVar> BlockVar(decimal amount)
    {
        return [new MegaCrit.Sts2.Core.Localization.DynamicVars.BlockVar(amount, ValueProp.Move)];
    }
}
