using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class PerfectCatchCard : SeaborneCard
{
    public override bool HasCastOrReel => true;

    private int _reelAmount = 2;

    public PerfectCatchCard() : base(2, CardType.Skill, CardRarity.Rare, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.Reel(ModifyGemReel(_reelAmount));
        SeaborneGemSystem.RechargeAll();
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _reelAmount = 3;
    }
}
