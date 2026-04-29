using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class MucusMaskCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _slipperyAmount = 1;

    public MucusMaskCard() : base(1, CardType.Skill, CardRarity.Common, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainSlippery(ModifyGemStacks(_slipperyAmount));
    }

    protected override void OnUpgrade()
    {
        _slipperyAmount = 2;
    }
}
