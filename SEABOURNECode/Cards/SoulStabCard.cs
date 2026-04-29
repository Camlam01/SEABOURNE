using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SoulStabCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;
    public SoulStabCard() : base(0, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await DamageCmd.Attack(ModifyGemDamage(IsSeaborneUpgraded ? 7m : 5m)).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
        await SeaborneCardTools.ApplyVulnerable(cardPlay.Target, ModifyGemStacks(1));
        await SeaborneCardTools.ApplyImbued(IsSeaborneUpgraded ? 2 : 1);
        await ApplyGemWetIfAny();
    }
}
