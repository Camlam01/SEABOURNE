using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class VaultCard() : SeaborneCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    private int slots = 2;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Gain(play, new GemSlotPower(), slots);
    }

    protected override void OnUpgrade()
    {
        slots = 3;
    }
}
