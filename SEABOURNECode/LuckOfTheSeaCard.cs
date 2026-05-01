using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class LuckOfTheSeaCard() : SeaborneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    private int choices = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Reel(play, 2);
        for (var i = 0
        i < choices;
        i++) await SeaborneCardRuntime.GainRandomGem(play);
        await Gain(play, new WetCardPower(), 1);
    }

    protected override void OnUpgrade()
    {
        choices = 3;
    }
}
