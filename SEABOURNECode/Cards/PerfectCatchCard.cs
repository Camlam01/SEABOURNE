using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Systems;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class PerfectCatchCard : SeaborneCard
{
    public override bool HasCastOrReel => true;

    public PerfectCatchCard() : base(2, CardType.Skill, CardRarity.Rare, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.Reel(ModifyGemReel(IsSeaborneUpgraded ? 3 : 2));
        SeaborneGemSystem.RechargeAll();
        await ApplyGemWetIfAny();
    }
}
