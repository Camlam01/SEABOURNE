using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class FishermansFortitudePower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPowerAmountChanged(PowerModel power, decimal amount, Creature? applier, CardModel? cardSource)
    {
        if (Owner is null || power.Owner != Owner || power is not CastPower || amount <= 0 || cardSource is null)
            return;

        await GainBlockAsync(Amount);
    }
}
