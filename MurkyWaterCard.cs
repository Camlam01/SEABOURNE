using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class MurkyWaterCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _waterwallAmount = 25;

    public MurkyWaterCard() : base(2, CardType.Skill, CardRarity.Rare, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainWaterwall(ModifyGemStacks(_waterwallAmount));
    }

    protected override void OnUpgrade()
    {
        _waterwallAmount = 30;
    }
}
