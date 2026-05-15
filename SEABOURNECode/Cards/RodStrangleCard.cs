using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class RodStrangleCard() : SeaborneCard(1, CardType.Attack, CardRarity.Uncommon, TargetType.AllEnemies)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await DealAll(play, SeaborneCardRuntime.CurrentCast(play));
        await Reel(play);
    }

    protected override void OnUpgrade()
    {
        UpgradeCost(0);
    }
}
