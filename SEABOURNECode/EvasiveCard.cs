using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class EvasiveCard() : SeaborneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    private int slippery = 5;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Gain(play, new EvasivePower(), 1);
        await Gain(play, new SlipperyPower(), slippery);
    }

    protected override void OnUpgrade()
    {
        slippery = 7;
    }
}
