using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class EnchantedRodPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    private sealed class Data { public bool UsedThisTurn; }

    protected override object InitInternalData()
    {
        return new Data();
    }

    public bool CanImbueReeledCard()
    {
        return !GetInternalData<Data>().UsedThisTurn;
    }

    public void MarkUsed()
    {
        GetInternalData<Data>().UsedThisTurn = true;
    }

    public void ResetTurn()
    {
        GetInternalData<Data>().UsedThisTurn = false;
    }
}
