using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class EntangleCard() : SeaborneCard(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies)
{
    private int weak = 1;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Cast(play, 2);
        await ApplyAll(play, new WeakPower(), weak);
    }

    protected override void OnUpgrade()
    {
        weak = 2;
    }
}
