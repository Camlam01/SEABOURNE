using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class GemSlotPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        if (Owner is not null)
            SeabourneState.Gems(Owner).SlotCount = Math.Max(1, SeabourneState.Gems(Owner).SlotCount + Amount);

        return Task.CompletedTask;
    }

    public override Task BeforePowerAmountChanged(PowerModel power, decimal amount, Creature target, Creature? applier, CardModel? cardSource)
    {
        if (Owner is null || power != this)
            return Task.CompletedTask;

        var delta = (int)amount - Amount;
        if (delta != 0)
            SeabourneState.Gems(Owner).SlotCount = Math.Max(1, SeabourneState.Gems(Owner).SlotCount + delta);

        return Task.CompletedTask;
    }

    public override Task AfterRemoved(Creature oldOwner)
    {
        SeabourneState.Gems(oldOwner).SlotCount = Math.Max(1, SeabourneState.Gems(oldOwner).SlotCount - Amount);
        return Task.CompletedTask;
    }
}
