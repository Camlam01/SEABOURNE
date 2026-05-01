using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class RiptideCard() : SeaborneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    private int blockPerCard = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await GainBlock(play, blockPerCard * SeaborneCardRuntime.CardsInHand(play));
    }

    protected override void OnUpgrade()
    {
        blockPerCard = 3;
    }
}
