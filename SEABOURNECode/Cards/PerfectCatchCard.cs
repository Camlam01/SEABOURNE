using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class PerfectCatchCard() : SeaborneCard(2, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    private int enchantCount = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Reel(play);
        await SeaborneCardRuntime.EnchantFirstReeledCards(play, enchantCount);
    }

    protected override void OnUpgrade()
    {
        enchantCount = 3;
    }
}
