using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class WaterborneCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public WaterborneCard() : base(2, CardType.Skill, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToPlayer(WetCardPower.Id, ModifyGemStacks(1));
        await SeaborneCardTools.GainWaterwall(ModifyGemStacks(IsSeaborneUpgraded ? 12 : 8));
    }
}
