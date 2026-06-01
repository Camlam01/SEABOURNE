using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace. CardType, CardRarity, CardTag and CardTarget are resolved via global imports or the Entities.Cards namespace.
using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// Base class for all Seabourne cards.  This class derives from
    /// <see cref="CustomCardModel"/> and exposes helper methods for common
    /// functionality such as creating card IDs, tag collections and dynamic
    /// variable sequences.  Concrete card classes should inherit from
    /// <c>SeabourneCard</c> instead of <c>CustomCardModel</c> directly.
    /// </summary>
    public abstract class SeabourneCard : CustomCardModel
    {
        /// <summary>
        /// Combines a series of card tags into a <see cref="CardAspectSequence"/>.
        /// Tags are used for filtering, localisation and interactions.  When
        /// defining tags on your cards, pass them to this method instead of
        /// calling <see cref="CardTagsProvider.From"/> manually.
        /// </summary>
        /// <param name="tags">The tags to include.</param>
        /// <returns>A sequence representing the provided tags.</returns>
        protected static CardAspectSequence Tags(params CardTag[] tags)
        {
            return CardTagsProvider.Instance.From(tags);
        }

        /// <summary>
        /// Combines a series of dynamic variables into a <see cref="CardVarSequence"/>.
        /// Dynamic variables drive the numbers displayed on cards (e.g. damage,
        /// block, cast depth).  When defining variables for your cards, use
        /// this helper rather than calling <see cref="CardVarsProvider.From"/>
        /// directly.
        /// </summary>
        /// <param name="vars">The dynamic variables to include.</param>
        /// <returns>A sequence representing the provided dynamic variables.</returns>
        protected static CardVarSequence Vars(params IDynamicVar[] vars)
        {
            return CardVarsProvider.Instance.From(vars);
        }

        /// <summary>
        /// Generates a fully qualified ID for a card.  All Seabourne cards should
        /// use the format "Seabourne:&lt;Name&gt;" to avoid clashes with other
        /// mods.  Passing the simple name to this method ensures consistent
        /// formatting across the codebase.
        /// </summary>
        /// <param name="simpleName">The unqualified card name.</param>
        /// <returns>The fully qualified ID.</returns>
        protected static string MakeId(string simpleName)
        {
            return $"Seabourne:{simpleName}";
        }

        /// <summary>
        /// Determines whether this card should move to the discard pile when it
        /// resolves.  Override this in derived classes to implement mechanics
        /// such as Load where the card does not immediately leave the hand.
        /// </summary>
        /// <returns><c>true</c> if the card should move to the discard pile; otherwise <c>false</c>.</returns>
        public override bool ShouldMoveToDiscard() => true;
    }
}