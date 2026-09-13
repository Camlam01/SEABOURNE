using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
// Bring in the base models namespace so that we can reference CardModel unambiguously.
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Powers;

// Alias CardModel to the version from the models namespace. There is a CardModel type in
// MegaCrit.Sts2.Core.Entities as well, but the commands APIs operate on the model version.
namespace SEABOURNE.SEABOURNECode.Extensions
{
    /// <summary>
    /// Provides helper methods for resolving the reel mechanic. Reeling pulls a sequence of cards
    /// from the discard pile back into the player's hand based on the current cast power.
    /// </summary>
    public static class ReelUtils
    {
        /// <summary>
        /// Performs the reel operation for the given player. Cards between the hooked card and
        /// the most recently discarded card (inclusive) are moved from the discard pile to the
        /// hand. If a card has Wet stacks it will instead be automatically played. After reeling
        /// the player's CastPower is removed.
        /// </summary>
        /// <param name="player">The player performing the reel.</param>
        public static async Task ReelAsync(Player player)
        {
            int castAmount = (int)player.Creature.GetPowerAmount<CastPower>();
            if (castAmount <= 0) return;

            CardPile discardPile = PileType.Discard.GetPile(player);
            List<CardModel> cardsToReel = discardPile.Cards
                .TakeLast(Math.Min(castAmount, discardPile.Cards.Count))
                .ToList();

            foreach (var card in cardsToReel)
            {
                await CardPileCmd.Add(card, PileType.Hand, CardPilePosition.Top);
            }

            var castPower = player.Creature.GetPower<CastPower>();
            if (castPower != null)
            {
                await PowerCmd.Remove(castPower);
            }
        }
    }
}
