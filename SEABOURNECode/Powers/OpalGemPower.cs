using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;

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
            await PowerCmd.Apply<CastPower>(base.Owner, 1m, base.Owner, cardPlay.Card, false);
            MarkUsed();
        }
    }
}