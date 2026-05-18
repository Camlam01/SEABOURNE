using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class SorcererFormPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    private void ImbueIfOwned(CardModel card)
    {
        if (Owner is null)
            return;

        if (SeabourneReflection.GetOwner(card) != Owner)
            return;

        SeabourneState.Card(card).ImbuedStacks = Math.Max(SeabourneState.Card(card).ImbuedStacks, Amount);
    }

    public override Task AfterCardEnteredCombat(CardModel card)
    {
        ImbueIfOwned(card);
        return Task.CompletedTask;
    }

    public override Task AfterCardGeneratedForCombat(CardModel card, bool addedByPlayer)
    {
        ImbueIfOwned(card);
        return Task.CompletedTask;
    }

    public override Task AfterCardDrawn(PlayerChoiceContext choiceContext, CardModel card, bool fromHandDraw)
    {
        ImbueIfOwned(card);
        return Task.CompletedTask;
    }
}
