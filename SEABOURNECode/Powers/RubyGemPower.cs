using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using BaseLib.Abstracts;
using BaseLib.Utils;

// Import models namespace for PowerType definitions.
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that increases the damage of the first attack played each turn by 20%.
    /// Additional stacks of this power increase the multiplier further. After the first
    /// attack card is played the gem becomes inactive until the next turn.
    /// </summary>
    public sealed class RubyGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/RubyGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/RubyGemPower.png";

        /// <summary>
        /// When the first attack card is played this turn the gem triggers and marks itself used.
        /// </summary>
        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            CardModel card = cardPlay.Card;
            if (card.Type != CardType.Attack)
            {
                return Task.CompletedTask;
            }

            // Trigger the gem: flash and mark used.
            this.Flash();
            MarkUsed();
            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        public override decimal ModifyDamageMultiplicative(Creature? target, decimal amount, ValueProp props, Creature? dealer, CardModel? cardSource)
        {
            // Only modify attack damage dealt by our owner before the gem has been used.
            if (!UsedThisTurn && dealer == base.Owner && cardSource != null && cardSource.Type == CardType.Attack)
            {
                // 20% per stack.
                return 1m + (0.2m * base.Amount);
            }
            return 1m;
        }
    }
}