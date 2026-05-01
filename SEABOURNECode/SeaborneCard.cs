using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

[Pool(typeof(SEABOURNECardPool))]
public abstract class SeaborneCard(
    int cost,
    CardType type,
    CardRarity rarity,
    TargetType target
) : CustomCardModel(cost, type, rarity, target)
{
    protected decimal Damage => DynamicVars.TryGetValue("Damage", out var value) ? value.Value : 0m;
    protected decimal Block => DynamicVars.TryGetValue("Block", out var value) ? value.Value : 0m;

    public override string PortraitPath => "res://SEABOURNE/images/card_placeholder.png";
    public override string BetaPortraitPath => PortraitPath;

    protected void UpgradeDamage(decimal amount) => DynamicVars["Damage"].UpgradeValueBy(amount);
    protected void UpgradeBlock(decimal amount) => DynamicVars["Block"].UpgradeValueBy(amount);
    protected void UpgradeCost(int newCost) => SeaborneCardRuntime.SetCost(this, newCost);

    protected Task Deal(CardPlay play, decimal damage) => CommonActions.CardDamage(this, play, damage);
    protected Task DealAll(CardPlay play, decimal damage) => CommonActions.CardDamageToAllEnemies(this, play, damage);
    protected Task GainBlock(CardPlay play, decimal block) => CommonActions.CardBlock(this, play, block);
    protected Task Gain(CardPlay play, object power, int amount) => CommonActions.GainPower(this, play, power, amount);
    protected Task Apply(CardPlay play, object power, int amount) => CommonActions.ApplyPower(this, play, power, amount);
    protected Task ApplyAll(CardPlay play, object power, int amount) => CommonActions.ApplyPowerToAllEnemies(this, play, power, amount);

    protected Task Cast(CardPlay play, int amount) => SeaborneCardRuntime.Cast(play, amount);
    protected Task Reel(CardPlay play, int amount) => SeaborneCardRuntime.Reel(play, amount);
    protected Task Acquire(CardPlay play, object gem) => SeaborneCardRuntime.AcquireGem(play, gem);
    protected Task FireCannon(CardPlay play, decimal baseDamage = 20m, bool targetOnly = false) => SeaborneCardRuntime.FireCannon(play, baseDamage, targetOnly);
    protected Task LoadCannon(CardPlay play, decimal baseDamage) => SeaborneCardRuntime.LoadCannon(play, baseDamage);
    protected Task AddCannonballs(CardPlay play, int count) => SeaborneCardRuntime.AddCannonballs(play, count);
}

public interface ISeaborneWetCard
{
    Task OnReeled(CardPlay play);
}
