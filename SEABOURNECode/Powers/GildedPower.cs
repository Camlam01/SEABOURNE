using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class GildedPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    private Task TryTrigger()
    {
        if (OwnerRef is null)
            return Task.CompletedTask;

        var turn = SeabourneState.Turn(OwnerRef);
        if (turn.GildedTriggered || HandCount() < 10)
            return Task.CompletedTask;

        turn.GildedTriggered = true;
        GainEnergy(Amount);
        return Task.CompletedTask;
    }

    public override Task AfterCardDrawn(PlayerChoiceContext choiceContext, CardModel card, bool fromHandDraw) => TryTrigger();
    public override Task AfterCardRetained(CardModel card) => TryTrigger();
    public override Task AfterCardPlayedLate(PlayerChoiceContext choiceContext, CardPlay cardPlay) => TryTrigger();
}
