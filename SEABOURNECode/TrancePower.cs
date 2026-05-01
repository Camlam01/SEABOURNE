using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class TrancePower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Debuff;

    public override PowerStackType StackType => PowerStackType.Counter;

    public bool PreventsIntentProgression => Amount > 0;

    public bool PreventsEndOfTurnScaling => Amount > 0;

    public int GetDecayAtStartOfPlayerTurn()
    {
        return 1 + SeabornePowerRuntime.Amount<TranceResistancePower>(Owner);
    }
}
