using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that applies one stack of Wet to the first card played each turn.
    /// Applying wet to cards requires specialised logic; this class simply marks
    /// the gem as used and flashes when triggered.
    /// </summary>
    public sealed class DiamondGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/DiamondGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/DiamondGemPower.png";

        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            // Logic for applying wet to the card should be implemented in card code.
            this.Flash();
            MarkUsed();
            return Task.CompletedTask;
        }
    }
}