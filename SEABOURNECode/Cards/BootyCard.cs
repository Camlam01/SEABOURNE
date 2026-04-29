using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class BootyCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    public BootyCard() : base(3, CardType.Skill, CardRarity.Rare, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await BlockCmd.Gain(IsSeaborneUpgraded ? 20m : 15m).FromCard(this).Execute(choiceContext);
        await SeaborneCardTools.GainGemSlot(ModifyGemStacks(1));
        await SeaborneCardTools.AcquireGem(IsSeaborneUpgraded ? OpalGemPower.Id : AmberGemPower.Id);
        await ApplyGemWetIfAny();
    }
}
