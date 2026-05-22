using System;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;

// Import models namespace to ensure PowerType, PowerStackType and other model definitions are resolved.
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Tracks the current depth of the player's hook into the discard pile.
    /// Each stack of cast corresponds to one card deeper in the discard pile.
    /// When reel is triggered the stacks are consumed.
    /// </summary>
    public sealed class CastPower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <summary>
        /// Cast does not allow negative values; stacks are removed explicitly on reel.
        /// </summary>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/CastPower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/CastPower.png";

        /// <summary>
        /// Gets the current cast depth as an integer. Convenience accessor for card logic.
        /// </summary>
        public int Depth => (int)this.Amount;
    }
}