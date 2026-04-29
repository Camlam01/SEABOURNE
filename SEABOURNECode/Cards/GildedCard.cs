using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class GildedCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _energyGain = 2;

    public GildedCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToPlayer(GildedPower.Id, ModifyGemStacks(_energyGain));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _energyGain = 3;
    }
}
