using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class IdolatryCard() : SeaborneCard(2, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    private int damage = 4;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Gain(play, new IdolatryPower(), damage);
    }

    protected override void OnUpgrade()
    {
        damage = 6;
    }
}
