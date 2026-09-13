using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.ValueProps;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using BaseLib.Abstracts;
using BaseLib.Utils;

// Import card model definitions for CardModel type used in block modification.
using MegaCrit.Sts2.Core.Models.Cards;

// Import models namespace for PowerType definitions.
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that increases the block of the first skill played each turn by 20%.
    /// Additional stacks of this power increase the multiplier further.
    /// </summary>
    public sealed class SapphireGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/SapphireGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/SapphireGemPower.png";

        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            var card = cardPlay.Card;
            if (card.Type != CardType.Skill)
            {
                return Task.CompletedTask;
            }
            this.Flash();
            MarkUsed();
            return Task.CompletedTask;
        }

        // The block modifier hook is intentionally deferred until the gem
        // vertical slice. Its previous signature belonged to an older STS2
        // API and prevented the starter character from compiling.
    }
}
