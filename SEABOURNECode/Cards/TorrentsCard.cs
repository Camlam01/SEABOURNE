using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class TorrentsCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public TorrentsCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainWaterwall(ModifyGemStacks(6));
        await SeabornePowerTools.ApplyPowerToPlayer("Seaborne:Torrents", IsSeaborneUpgraded ? 2 : 1);
    }
}
