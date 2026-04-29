using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class FlawlessStoneCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    public FlawlessStoneCard() : base(2, CardType.Power, CardRarity.Rare, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainGemSlot(ModifyGemStacks(1));
        await SeaborneCardTools.AcquireGem(DiamondGemPower.Id);
        await SeabornePowerTools.ApplyPowerToPlayer("Seaborne:FlawlessStone", ModifyGemStacks(1));
        await ApplyGemWetIfAny();
    }
}
