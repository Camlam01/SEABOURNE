using System.Linq;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace.  Enumerations such as CardType, CardRarity and TargetType are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// Base class for all Seabourne card models.  This class derives from
    /// <see cref="CustomCardModel"/> and exposes helper methods for common
    /// functionality such as creating card IDs, tag collections and dynamic
    /// variable sequences.  Concrete card classes should inherit from
    /// <c>SeabourneCardModel</c> instead of <c>CustomCardModel</c> directly.
    /// </summary>
    public abstract class SeabourneCardModel : CustomCardModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeabourneCardModel"/> class.
        /// Passes the provided parameters through to the base <see cref="CustomCardModel"/>
        /// constructor.  Derived classes should call this constructor from their
        /// own constructors to set up energy cost, type, rarity and target.
        /// </summary>
        /// <param name="cost">Base energy cost.</param>
        /// <param name="type">Card type.</param>
        /// <param name="rarity">Card rarity.</param>
        /// <param name="target">Target type.</param>
        /// <param name="showInCardLibrary">Whether to display in the card library.</param>
        /// <param name="autoAdd">Whether to auto-register the model.</param>
        /// <remarks>
        /// Note: STS2 defines card targeting using <see cref="CardTarget"/> rather than
        /// the unused <c>TargetType</c>.  Using <see cref="CardTarget"/> here avoids
        /// compile errors when the real API is present.
        /// </remarks>
        protected SeabourneCardModel(int cost, CardType type, CardRarity rarity, CardTarget target, bool showInCardLibrary = true, bool autoAdd = true)
            : base(cost, type, rarity, target, showInCardLibrary, autoAdd)
        {
        }

        /// <summary>
        /// Combines a series of card tags into a <see cref="CardAspectSequence"/>.
        /// Tags are used for filtering, localisation and interactions.  When
        /// defining tags on your cards, pass them to this method instead of
        /// calling <see cref="CardTagsProvider.Instance.From(CardTag[])"/> manually.
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
        /// this helper rather than calling <see cref="CardVarsProvider.Instance.From"/>
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
        /// resolves.  Override this to implement loading or other mechanics
        /// where the card does not leave the hand immediately after play.  By
        /// default, cards always move to the discard pile.
        /// </summary>
        /// <returns><c>true</c> if the card should move to the discard pile;
        /// otherwise <c>false</c>.</returns>
        public virtual bool ShouldMoveToDiscard() => true;
    }
}