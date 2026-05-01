
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

public class WaterwallEndRelic : SeaborneRelic
{
    public override void OnTurnEnd() { Owner.ApplyPower(new WaterwallPower(), 5); }
}
