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

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Gem power that increases the number of stacks applied by buffs and debuffs by one.
    /// The exact behaviour must be implemented in card and power definitions. This class
    /// serves as a marker to indicate the presence of the Emerald gem and recharges each turn.
    /// </summary>
    public sealed class EmeraldGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/EmeraldGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/EmeraldGemPower.png";

        protected override Task OnCardPlayed(PlayerChoiceContext context, CardPlay cardPlay)
        {
            // Emerald modifies stack counts when powers or debuffs are applied.
            // Actual logic should be implemented elsewhere; here we just mark the gem as used.
            this.Flash();
            MarkUsed();
            return Task.CompletedTask;
        }
    }
}