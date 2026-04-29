using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class PullThroughCard : SeaborneCard
{
    public override bool HasCastOrReel => true;

    protected override IEnumerable<DynamicVar> CanonicalVars => BlockVar(10m);

    private int _reelAmount = 3;

    public PullThroughCard() : base(2, CardType.Skill, CardRarity.Common, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.Reel(ModifyGemReel(_reelAmount));
        await BlockCmd.Gain(DynamicVars.Block.BaseValue).FromCard(this).Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        _reelAmount = 4;
    }
}
