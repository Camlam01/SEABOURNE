
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

public class CannonDamageRelic : SeaborneRelic
{
    public override void ModifyCannonDamage(ref int dmg) { dmg += 5; }
}
