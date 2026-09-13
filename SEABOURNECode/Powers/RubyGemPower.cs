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

        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            CardModel card = cardPlay.Card;
            if (card.Type != CardType.Attack)
            {
                return Task.CompletedTask;
            }

            Flash();
            MarkUsed();
            return Task.CompletedTask;
        }

        // The damage modifier hook is intentionally deferred until the gem
        // vertical slice. Its previous signature belonged to an older STS2
        // API and prevented the starter character from compiling.
    }
}
