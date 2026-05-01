using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class FullyLoadedCard() : SeaborneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    private int reel = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Reel(play, reel);
        await SeaborneCardRuntime.LoadAllCannonballsInHand(play);
    }

    protected override void OnUpgrade()
    {
        reel = 3;
    }
}
