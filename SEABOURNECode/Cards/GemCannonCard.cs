using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class GemCannonCard() : SeaborneCard(2, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
{
    private int damagePerGem = 20;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await SeaborneCardRuntime.FireAllGems(play, damagePerGem);
    }

    protected override void OnUpgrade()
    {
        damagePerGem = 30;
    }
}
