using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class FireAndWaterCard : SeaborneCard
{
    public override bool HasAttackDamage => true;

    public FireAndWaterCard() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AcquireGem(IsSeaborneUpgraded ? SapphireGemPower.Id : RubyGemPower.Id);
        await DamageCmd.Attack(ModifyGemDamage(5m)).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
        await BlockCmd.Gain(5m).FromCard(this).Execute(choiceContext);
        await ApplyGemWetIfAny();
    }
}
