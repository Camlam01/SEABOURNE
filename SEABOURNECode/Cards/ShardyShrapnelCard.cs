using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class ShardyShrapnelCard() : SeaborneCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    private int amount = 6;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Gain(play, new ShardyShrapnelPower(), amount);
    }

    protected override void OnUpgrade()
    {
        amount = 8;
    }
}
