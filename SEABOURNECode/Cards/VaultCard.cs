using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class VaultCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    public VaultCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainGemSlot(ModifyGemStacks(IsSeaborneUpgraded ? 3 : 2));
        await ApplyGemWetIfAny();
    }
}
