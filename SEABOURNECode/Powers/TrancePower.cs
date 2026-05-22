using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Combat;
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
    /// Applies the Trance debuff to an enemy. Enemies under Trance do not progress their AI
    /// when their turn would end, effectively locking them into their current intent. Each
    /// turn Trance loses one stack until it expires.
    /// </summary>
    public sealed class TrancePower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Debuff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/TrancePower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/TrancePower.png";

        // Note: The base CustomPowerModel does not expose an AfterTurnEnd hook. To
        // implement Trance decay, you may need to handle stack reduction via
        // another mechanism (for example, within the card that applies Trance
        // or via an external game action).
    }
}