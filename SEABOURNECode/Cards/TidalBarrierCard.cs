using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class TidalBarrierCard() : SeaborneCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    private int times = 3;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        for (var i = 0
        i < times;
        i++) await Gain(play, new WaterwallPower(), 4);
    }

    protected override void OnUpgrade()
    {
        times = 4;
    }
}
