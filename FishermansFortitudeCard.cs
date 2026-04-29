using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class FishermansFortitudeCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _blockOnReel = 3;

    public FishermansFortitudeCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToPlayer(FishermansFortitudePower.Id, ModifyGemStacks(_blockOnReel));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _blockOnReel = 4;
    }
}
