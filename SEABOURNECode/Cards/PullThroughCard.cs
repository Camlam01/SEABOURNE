using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class PullThroughCard() : SeaborneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(11m, ValueProp.Block)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Reel(play);
        await GainBlock(play, Block);
    }

    protected override void OnUpgrade()
    {
        UpgradeBlock(3m);
    }
}
