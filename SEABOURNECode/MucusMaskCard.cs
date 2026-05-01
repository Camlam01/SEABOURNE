using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class MucusMaskCard() : SeaborneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    private int slippery = 1;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Gain(play, new SlipperyPower(), slippery);
        slippery = Math.Max(0, slippery - 1);
    }

    protected override void OnUpgrade()
    {
        slippery = 2;
    }
}
