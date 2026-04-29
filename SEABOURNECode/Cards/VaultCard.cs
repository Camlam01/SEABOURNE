using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class VaultCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _gemSlots = 2;

    public VaultCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainGemSlot(ModifyGemStacks(_gemSlots));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _gemSlots = 3;
    }
}
