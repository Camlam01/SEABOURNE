using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class WashCard() : SeaborneCard(-1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    private int bonus = 0;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await SeaborneCardRuntime.Wash(play, play.EnergySpent + bonus);
    }

    protected override void OnUpgrade()
    {
        bonus = 1;
    }
}
