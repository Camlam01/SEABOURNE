using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class OceanicOpalCard() : SeaborneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Acquire(play, new OpalGemPower());
        await Reel(play);
    }

    protected override void OnUpgrade()
    {
        UpgradeCost(0);
    }
}
