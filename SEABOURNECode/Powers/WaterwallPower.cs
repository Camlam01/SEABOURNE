using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Combat;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Represents a temporary barrier that deflects attacks up to its value. Waterwall blocks
    /// attack damage only if the incoming damage is less than or equal to the current stacks.
    /// If an attack is deflected no damage is taken; otherwise it blocks nothing. Waterwall
    /// naturally decays at the end of each of the owner's turns.
    /// </summary>
    public sealed class WaterwallPower : CustomPowerModel
    {
        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <inheritdoc/>
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/WaterwallPower.png";

        /// <inheritdoc/>
        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/WaterwallPower.png";

        /// <summary>
        /// Called at the end of the owner's turn to remove all stacks of Waterwall.
        /// </summary>
        public override async Task AfterTurnEnd(PlayerChoiceContext context, CombatSide side)
        {
            if (side == base.Owner.Side)
            {
                // At the end of your turn Waterwall dissipates.
                await PowerCmd.Remove(this);
            }
        }

        /// <summary>
        /// Determines whether the Waterwall would block the specified amount of damage.
        /// Card logic can call this helper when deciding whether to negate damage.
        /// </summary>
        /// <param name="incomingDamage">The damage value being dealt.</param>
        /// <returns><c>true</c> if Waterwall will block the hit; otherwise <c>false</c>.</returns>
        public bool CanBlock(decimal incomingDamage) => incomingDamage <= this.Amount;
    }
}