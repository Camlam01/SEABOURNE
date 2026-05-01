using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class EmpowerCard() : SeaborneCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Enemy)
{
    private int trance = 5;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Apply(play, new TrancePower(), trance);
        await Apply(play, new StrengthPower(), 3);
    }

    protected override void OnUpgrade()
    {
        trance = 6;
    }
}
