using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class BarteringCard() : SeaborneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    private int gold = 15;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await SeaborneCardRuntime.RemoveAllGemsForGold(play, gold);
        await Gain(play, new BarteringPower(), 1);
    }

    protected override void OnUpgrade()
    {
        gold = 25;
    }
}
