using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models.Cards;
using SEABOURNE.SEABOURNECode.Powers;

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
            var cards = discardPile.Cards.ToList();
            int toTake = Math.Min(castAmount, cards.Count);

            // Collect the cards to reel in correct order: from deepest (oldest) to newest.
            List<CardModel> cardsToReel = new List<CardModel>();
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
                // Remove from discard.
                await CardPileCmd.Remove(card, PileType.Discard);

                // Check for WetPower; if present the card should autoplay.
                bool hasWet = card.Powers?.OfType<WetPower>().Any() == true;
                if (hasWet)
                {
                    await CardCmd.AutoPlay(context, card, null, AutoPlayType.Default, true, false);
                }
                else
                {
                    // If the hand is full the card goes back to the discard pile according to
                    // standard Slay the Spire rules.
                    var hand = PileType.Hand.GetPile(player);
                    if (hand.Cards.Count >= player.MaxHandSize)
                    {
                        await CardPileCmd.Add(card, PileType.Discard, CardPilePosition.Top, null, false);
                    }
                    else
                    {
                        await CardPileCmd.Add(card, PileType.Hand, CardPilePosition.Top, null, false);
                    }
                }
            }

            // Remove all cast stacks after reeling.
            var castPower = player.Creature.GetPower<CastPower>();
            if (castPower != null)
            {
                await PowerCmd.Remove(castPower);
            }
        }
    }
}