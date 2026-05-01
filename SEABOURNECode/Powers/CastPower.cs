using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class CastPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public int HookDepth => Amount;

    public int GetHookIndexFromTopOfDiscard(int discardCount)
    {
        if (discardCount <= 0) return -1;
        return Math.Clamp(HookDepth - 1, 0, discardCount - 1);
    }
}
