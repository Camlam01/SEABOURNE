using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EmpowerCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _tranceAmount = 5;

    public EmpowerCard() : base(2, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.ApplyTrance(cardPlay.Target!, ModifyGemStacks(_tranceAmount));
        await SeabornePowerTools.ApplyPowerToTarget(cardPlay.Target!, "Strength", ModifyGemStacks(3));
    }

    protected override void OnUpgrade()
    {
        _tranceAmount = 6;
    }
}
