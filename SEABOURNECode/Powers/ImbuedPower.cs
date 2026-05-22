using MegaCrit.Sts2.Core.Models.Powers;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Indicates that a card is imbued. Imbued cards receive bonus effects from
    /// gem enhancements. The number of imbued stacks determines how many extra
    /// times a gem's effect is applied.
    /// </summary>
    public sealed class ImbuedPower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/ImbuedPower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/ImbuedPower.png";

        /// <summary>
        /// Convenience getter for the imbued level.
        /// </summary>
        public int Level => (int)this.Amount;
    }
}