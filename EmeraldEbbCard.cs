using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EmeraldEbbCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _waterwallAmount = 8;

    public EmeraldEbbCard() : base(2, CardType.Skill, CardRarity.Common, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AcquireGem(EmeraldGemPower.Id);
        await SeaborneCardTools.GainWaterwall(ModifyGemStacks(_waterwallAmount));
    }

    protected override void OnUpgrade()
    {
        _waterwallAmount = 12;
    }
}
