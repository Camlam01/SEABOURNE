using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SirenSongCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _tranceAmount = 2;

    public SirenSongCard() : base(2, CardType.Skill, CardRarity.Common, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToTarget(cardPlay.Target!, "Seaborne:Trance", ModifyGemStacks(_tranceAmount));
    }

    protected override void OnUpgrade()
    {
        _tranceAmount = 3;
    }
}
