using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
// Bring in the base models namespace so that we can reference CardModel unambiguously.
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Powers;

// Alias CardModel to the version from the models namespace. There is a CardModel type in
// MegaCrit.Sts2.Core.Entities as well, but the commands APIs operate on the model version.
using ModelCard = MegaCrit.Sts2.Core.Models.CardModel;

namespace SEABOURNE.SEABOURNECode.Mechanics
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
        /// <param name="context">The current player choice context.</param>
        /// <param name="player">The player performing the reel.</param>
        public static async Task ReelAsync(PlayerChoiceContext context, Player player)
        {
            // Determine how many cards to reel based on CastPower stacks.
            int castAmount = player.Creature.GetPowerAmount<CastPower>();
            if (castAmount <= 0) return;

            // Obtain the discard pile; if empty nothing happens.
            CardPile discardPile = PileType.Discard.GetPile(player);
            if (discardPile == null || discardPile.Cards.Count == 0) return;

            // Determine which cards in the discard pile to retrieve. The discard pile is assumed
            // to have the most recently discarded card at the end of the list. We take up to
            // castAmount cards from the end.
            // Cast the discard pile cards to the model CardModel type. Some APIs operate on the
            // model version of CardModel, so we explicitly cast here. If the discard pile
            // contains entities other than CardModel, they will be ignored.
            var cards = discardPile.Cards.Cast<ModelCard>().ToList();
            int toTake = Math.Min(castAmount, cards.Count);

            // Collect the cards to reel in correct order: from deepest (oldest) to newest.
            List<ModelCard> cardsToReel = new List<ModelCard>();
            for (int i = cards.Count - toTake; i < cards.Count; i++)
            {
                if (i >= 0 && i < cards.Count)
                {
                    cardsToReel.Add(cards[i]);
                }
            }

            // Reel the cards.
            foreach (var card in cardsToReel)
            {
                // We do not need to explicitly remove the card from its current pile when using
                // CardPileCmd.Add; the command will automatically move the card from its
                // existing pile (discard) to the target pile. We avoid calling a non‑existent
                // Remove method on CardPileCmd.

                // Determine if the player's hand is full. Slay the Spire 2 uses a maximum hand
                // size of 10 cards; if the hand is full the card should be placed back into
                // the discard pile.  We compare the hand count against this constant rather
                // than referencing a nonexistent Player.MaxHandSize property.
                var hand = PileType.Hand.GetPile(player);
                bool handFull = hand != null && hand.Cards.Count >= 10;

                if (handFull)
                {
                    await CardPileCmd.Add(card, PileType.Discard, CardPilePosition.Top, null, false);
                }
                else
                {
                    await CardPileCmd.Add(card, PileType.Hand, CardPilePosition.Top, null, false);
                }
            }

            // Remove all cast stacks after reeling.
            var castPower = player.Creature.GetPower<CastPower>();
            if (castPower != null)
            {
                // Remove all stacks of CastPower via the fully-qualified PowerCmd. The Remove
                // method accepts a PowerModel instance and handles unhooking and clean‑up.
                await MegaCrit.Sts2.Core.Commands.PowerCmd.Remove(castPower);
            }
        }
    }
}