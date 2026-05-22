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
    /// Represents the number of gem slots the player currently has. Each slot can hold one gem.
    /// Gem slots are consumed when applying gem powers and increased by certain relics or cards.
    /// </summary>
    public sealed class GemSlotPower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/GemSlotPower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/GemSlotPower.png";

        /// <summary>
        /// Returns the number of gem slots.
        /// </summary>
        public int Slots => (int)this.Amount;
    }
}