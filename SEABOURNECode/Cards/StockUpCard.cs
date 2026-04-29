using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class StockUpCard : SeaborneCard
{
    private int _cannonballsToCreate = 2;

    public StockUpCard() : base(0, CardType.Skill, CardRarity.Common, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AddCannonballsToHand(_cannonballsToCreate);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _cannonballsToCreate = 3;
    }
}
