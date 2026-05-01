using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class HookshotCard() : SeaborneCard(2, CardType.Attack, CardRarity.Rare, TargetType.Enemy)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await FireCannon(play, 20m, targetOnly: true);
        await SeaborneCardRuntime.ReloadLastFiredCannonballs(play);
    }

    protected override void OnUpgrade()
    {
        UpgradeCost(1);
    }
}
