using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class ReadyForWarCard : SeaborneCard
{
    public override bool HasCastOrReel => true;

    private int _cannonballsToCreate = 1;

    public ReadyForWarCard() : base(0, CardType.Skill, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.AddCast(ModifyGemCast(3));
        await SeaborneCardTools.AddCannonballsToHand(_cannonballsToCreate);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _cannonballsToCreate = 2;
    }
}
