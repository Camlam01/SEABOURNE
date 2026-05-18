using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gilded power grants energy when the player's hand reaches a certain
    /// size for the first time each turn.  This minimal implementation
    /// declares the power metadata; behaviour should be implemented in
    /// runtime hooks.
    /// </summary>
    public sealed class GildedPower : SEABOURNEPower
    {
        public override PowerType Type => PowerType.Buff;
        public override PowerStackType StackType => PowerStackType.Counter;
    }
}