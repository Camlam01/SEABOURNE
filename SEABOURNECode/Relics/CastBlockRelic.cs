
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

public class CastBlockRelic : SeaborneRelic
{
    public override void OnCast() { Owner.GainBlock(2); }
}
