using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Fisherman's Fortitude grants the player block whenever they gain Cast.
    /// This minimal stub defines the power metadata.  Hook logic should be
    /// implemented elsewhere in the runtime.
    /// </summary>
    public sealed class FishermansFortitudePower : SEABOURNEPower
    {
        public override PowerType Type => PowerType.Buff;
        public override PowerStackType StackType => PowerStackType.Counter;
    }
}