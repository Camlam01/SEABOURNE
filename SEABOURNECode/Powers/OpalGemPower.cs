using System.Threading.Tasks;
// Note: Avoid importing Multiplayer namespace here to prevent ambiguous overloads of
// PowerCmd.Apply that require a PlayerChoiceContext.  We only need base command functionality.
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.ValueProps;
using BaseLib.Abstracts;
using BaseLib.Utils;

// Import models namespace for PowerType definitions.
using MegaCrit.Sts2.Core.Models;

// Import commands namespace for PowerCmd.
using MegaCrit.Sts2.Core.Commands;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that grants one stack of cast to the player when the first card is played
    /// each turn. This encourages fishing through the deck. After triggering it resets
    /// at the end of the player's turn.
    /// </summary>
    public sealed class OpalGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/OpalGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/OpalGemPower.png";

        protected override async Task OnCardPlayed(MegaCrit.Sts2.Core.GameActions.Multiplayer.PlayerChoiceContext context, CardPlay cardPlay)
        {
            // Grant one Cast when the first card is played this turn. Use the IEnumerable overload
            // of PowerCmd.Apply to avoid ambiguous resolution with multiplayer-specific overloads.
            // Pass a single-element array of the owner creature as the target; the applier is also
            // the owner creature. The card source is the card just played.  We set silent=false
            // so that the effect is visible.
            this.Flash();
            await MegaCrit.Sts2.Core.Commands.PowerCmd.Apply<CastPower>(
                new[] { base.Owner.Creature },
                1m,
                base.Owner.Creature,
                cardPlay.Card,
                false);
            MarkUsed();
        }
    }
}