using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class WaterwallPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public override bool ExpiresAtEndOfTurn => true;

    public bool BlocksAttackDamage(decimal incomingAttackDamage)
    {
        return incomingAttackDamage <= Amount;
    }

    public override decimal ModifyDamageAdditive(Creature? target, decimal amount, ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        if (target != Owner || amount <= 0m)
        {
            return 0m;
        }

        return BlocksAttackDamage(amount) ? -amount : 0m;
    }
}
