using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that reduces the cost of the first card played each turn by one and exhausts it.
    /// Actual cost modification and exhaust handling should be implemented in card logic. This
    /// power simply marks the gem as used when the first card is played.
    /// </summary>
    public sealed class AmberGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/AmberGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/AmberGemPower.png";

        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            // Card cost and exhaust modifications are handled in card code.
            this.Flash();
            MarkUsed();
            return Task.CompletedTask;
        }
    }
}