
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

public class DamageCastRelic : SeaborneRelic
{
    public override void OnTakeDamage() { Owner.ApplyPower(new CastPower(), 1); }
}
