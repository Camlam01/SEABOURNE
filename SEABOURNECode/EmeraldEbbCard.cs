using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class EmeraldEbbCard() : SeaborneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    private int waterwall = 8;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Acquire(play, new EmeraldGemPower());
        await Gain(play, new WaterwallPower(), waterwall);
    }

    protected override void OnUpgrade()
    {
        waterwall = 12;
    }
}
