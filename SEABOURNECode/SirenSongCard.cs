using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class SirenSongCard() : SeaborneCard(2, CardType.Skill, CardRarity.Common, TargetType.Enemy)
{
    private int trance = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Apply(play, new TrancePower(), trance);
    }

    protected override void OnUpgrade()
    {
        trance = 3;
    }
}
