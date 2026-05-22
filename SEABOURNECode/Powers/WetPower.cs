using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using BaseLib.Abstracts;
using BaseLib.Utils;

// Import models namespace for PowerType definitions.
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Applies the Wet effect to a card or creature. Wet stacks cause a card to automatically
    /// play itself when reeled in. Each stack of wet causes the card to be replayed that many
    /// times when reeled. This power simply tracks the number of wet stacks; the reel logic
    /// is handled elsewhere.
    /// </summary>
    public sealed class WetPower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/WetPower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/WetPower.png";

        /// <summary>
        /// Returns the number of Wet stacks as an integer.
        /// </summary>
        public int Stacks => (int)this.Amount;
    }
}