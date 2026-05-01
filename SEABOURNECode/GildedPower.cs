using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class GildedPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Counter;

    private sealed class Data { public bool TriggeredThisTurn; }

    protected override object InitInternalData()
    {
        return new Data();
    }

    public int RequiredHandSize => 10;

    public int EnergyToGain => Amount;

    public bool CanTrigger(int handSize)
    {
        return handSize >= RequiredHandSize && !GetInternalData<Data>().TriggeredThisTurn;
    }

    public void MarkTriggered()
    {
        GetInternalData<Data>().TriggeredThisTurn = true;
    }

    public void ResetTurn()
    {
        GetInternalData<Data>().TriggeredThisTurn = false;
    }
}
