using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class AncientCurseCard() : SeaborneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.AllEnemies)
{
    private int imbued = 1;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await ApplyAll(play, new VulnerablePower(), 1);
        await ApplyAll(play, new WeakPower(), 1);
        await Gain(play, new ImbuedPower(), imbued);
    }

    protected override void OnUpgrade()
    {
        imbued = 2;
    }
}
