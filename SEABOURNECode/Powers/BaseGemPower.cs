using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Base class for all gem powers. Each gem power provides a one-time
    /// enhancement to the first suitable card played each turn. After being
    /// used, the power deactivates until the start of the next turn.
    /// </summary>
    public abstract class BaseGemPower : CustomPowerModel
    {
        private bool _usedThisTurn;

        /// <inheritdoc/>
        public override PowerType Type => PowerType.Buff;

        /// <inheritdoc/>
        public override PowerStackType StackType => PowerStackType.Counter;

        /// <inheritdoc/>
        public override bool AllowNegative => false;

        /// <summary>
        /// Invoked after any card is played. Derived classes should override
        /// <see cref="OnCardPlayed"/> to implement their effect and call
        /// <see cref="MarkUsed"/> when triggered.
        /// </summary>
        public override async Task AfterCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            if (cardPlay?.Card == null) return;
            if (cardPlay.Card.Owner != base.Owner.Player) return;
            if (_usedThisTurn) return;
            await OnCardPlayed(context, cardPlay);
        }

        /// <summary>
        /// Reset gem powers at the end of the owner's turn so they recharge.
        /// </summary>
        public override Task AfterTurnEnd(PlayerChoiceContext context, CombatSide side)
        {
            if (side == base.Owner.Side)
            {
                _usedThisTurn = false;
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Derived classes implement their enhancement in this method. Call
        /// <see cref="MarkUsed"/> to mark the gem as consumed for the turn.
        /// </summary>
        protected abstract Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay);

        /// <summary>
        /// Marks the gem as used so it will not trigger again until the turn resets.
        /// </summary>
        protected void MarkUsed()
        {
            _usedThisTurn = true;
        }

        /// <summary>
        /// Allows derived classes to query whether the gem has already been used this turn.
        /// </summary>
        protected bool UsedThisTurn => _usedThisTurn;
    }
}