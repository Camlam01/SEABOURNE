using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
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

        protected override async Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            // Grant one Cast when the first card is played this turn.
            this.Flash();
            // Use the fully-qualified PowerCmd to avoid ambiguous or missing type resolution. This
            // call applies one stack of CastPower to the owner. Note that the generic parameter
            // identifies the type of power to apply, followed by the target creature, amount,
            // applier, card source, and silent flag.
            await MegaCrit.Sts2.Core.Commands.PowerCmd.Apply<CastPower>(base.Owner, 1m, base.Owner, cardPlay.Card, false);
            MarkUsed();
        }
    }
}