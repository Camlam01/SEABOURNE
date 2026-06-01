using System;
using System.Threading.Tasks;

// This file provides a collection of minimal stub types used solely to satisfy the
// compile‑time dependencies of the Seabourne mod when the full Slay the Spire 2
// API is unavailable.  None of the implementations contained herein are
// functional; they only define the names, methods and properties referenced
// throughout the card definitions.  If you are building against the actual
// STS2 codebase, these stubs should be removed in favour of the real types.

namespace MegaCrit.Sts2.Core.Models.Cards.Enums
{
    /// <summary>
    /// Represents the category of a card (attack, skill, power, etc.).
    /// </summary>
    // NOTE: Enumeration definitions have been removed from this stub.  The real STS2
    // library defines CardType, CardRarity, CardTag and CardTarget in the
    // MegaCrit.Sts2.Core.Entities.Cards namespace.  When building against the
    // actual API, those enums will be used instead of these stubs.  If you
    // encounter missing symbol errors, ensure the correct namespace is
    // imported in your card files (e.g. using MegaCrit.Sts2.Core.Entities.Cards;).
}

namespace MegaCrit.Sts2.Core.Models.Cards
{
    using MegaCrit.Sts2.Core.Models.Cards.Enums;
    using MegaCrit.Sts2.Core.Localization.DynamicVars;

    /// <summary>
    /// Represents the energy cost of a card.  Provides helper methods to
    /// construct and upgrade costs.  Only the fields used in the Seabourne
    /// project are implemented.
    /// </summary>
    public class EnergyCost
    {
        /// <summary>
        /// The base energy cost of the card.  Negative values can be used to
        /// denote unplayable cards or special behaviours.
        /// </summary>
        public int BaseCost { get; set; }

        /// <summary>
        /// Indicates whether this card uses X‑cost (variable) energy.
        /// </summary>
        public bool CostsX { get; set; }

        /// <summary>
        /// Factory method to create a fixed energy cost.  Use this when
        /// specifying the cost of a card.
        /// </summary>
        public static EnergyCost From(int cost) => new EnergyCost { BaseCost = cost };

        /// <summary>
        /// Alters the cost by the provided delta.  Costs cannot drop below
        /// zero via this method.
        /// </summary>
        public void UpgradeBy(int delta)
        {
            BaseCost = Math.Max(0, BaseCost + delta);
        }
    }

    /// <summary>
    /// A simple placeholder representing a collection of card tags.  The
    /// sequence itself carries no data; it only exists to satisfy type
    /// references.
    /// </summary>
    public class CardAspectSequence
    {
    }

    /// <summary>
    /// A simple placeholder representing a collection of dynamic variables.
    /// </summary>
    public class CardVarSequence
    {
    }

    /// <summary>
    /// Provides methods to construct <see cref="CardAspectSequence"/> objects
    /// from arrays of card tags.  In the full API this class would also
    /// perform localisation and keyword registration.
    /// </summary>
    public class CardTagsProvider
    {
        private static readonly CardTagsProvider _instance = new CardTagsProvider();
        public static CardTagsProvider Instance => _instance;

        public CardAspectSequence Empty => new CardAspectSequence();

        public CardAspectSequence From(params MegaCrit.Sts2.Core.Models.Cards.Enums.CardTag[] tags)
        {
            return new CardAspectSequence();
        }

        public CardAspectSequence From(params SEABOURNE.SEABOURNECode.SeabourneTag[] tags)
        {
            return new CardAspectSequence();
        }
    }

    /// <summary>
    /// Provides methods to construct <see cref="CardVarSequence"/> objects from
    /// arrays of dynamic variables.  In the full API this class would
    /// additionally register the variables with the localisation system.
    /// </summary>
    public class CardVarsProvider
    {
        private static readonly CardVarsProvider _instance = new CardVarsProvider();
        public static CardVarsProvider Instance => _instance;

        public CardVarSequence Empty => new CardVarSequence();

        public CardVarSequence From(params MegaCrit.Sts2.Core.Localization.DynamicVars.IDynamicVar[] vars)
        {
            return new CardVarSequence();
        }
    }

    /// <summary>
    /// Represents the context in which a card is being played.  This is a
    /// placeholder with no data; real implementations would carry targeting
    /// information and resolve results.
    /// </summary>
    public class CardPlayState
    {
    }
}

namespace MegaCrit.Sts2.Core.Entities.Cards
{
    /// <summary>
    /// A placeholder runtime instance for a card.  In the full game this would
    /// manage state like upgrades, enchantments and local modifiers.  Here it
    /// serves only to satisfy type references in extension methods.
    /// </summary>
    // NOTE: CardRuntime is defined in the real STS2 API.  This stub has been
    // removed to avoid conflicts with the actual implementation.  If you need
    // to reference CardRuntime within your extension methods, import it from
    // MegaCrit.Sts2.Core.Entities.Cards.
}

namespace MegaCrit.Sts2.Core.Localization.DynamicVars
{
    /// <summary>
    /// Marker interface for dynamic variables used in card descriptions.  In
    /// the real API this would expose methods for preview and update logic.
    /// </summary>
    public interface IDynamicVar
    {
    }

    // NOTE: Dynamic variable classes such as DamageVar, BlockVar, CastVar, ReelVar, CannonballVar
    // and EnergyVar have been removed from this stub.  These are provided by the actual
    // Slay the Spire 2 API in the same namespace.  When building against the
    // real game library, import MegaCrit.Sts2.Core.Localization.DynamicVars to access
    // the concrete implementations.  If you encounter missing symbol errors, ensure
    // the proper API assembly is referenced.
}

namespace BaseLib.Abstracts
{
    using MegaCrit.Sts2.Core.Models.Cards;
    using MegaCrit.Sts2.Core.Models.Cards.Enums;

    /// <summary>
    /// Minimal custom card model used for modding.  This stub defines the
    /// overridable members commonly used in card definitions.  It is not
    /// functional and should be replaced by the real game API when available.
    /// </summary>
    public abstract class CustomCardModel
    {
        /// <summary>Gets the display name of the card.</summary>
        public virtual string Name => string.Empty;
        /// <summary>Gets the description text shown on the card.</summary>
        public virtual string Description => string.Empty;
        /// <summary>Gets the energy cost required to play the card.</summary>
        public virtual EnergyCost? Cost => null;
        /// <summary>Gets the category of the card.</summary>
        public virtual MegaCrit.Sts2.Core.Entities.Cards.CardType Type => MegaCrit.Sts2.Core.Entities.Cards.CardType.Attack;
        /// <summary>Gets the rarity tier of the card.</summary>
        public virtual MegaCrit.Sts2.Core.Entities.Cards.CardRarity Rarity => MegaCrit.Sts2.Core.Entities.Cards.CardRarity.Common;
        /// <summary>Gets the default targeting for the card.</summary>
        public virtual MegaCrit.Sts2.Core.Entities.Cards.CardTarget Target => MegaCrit.Sts2.Core.Entities.Cards.CardTarget.Self;
        /// <summary>Gets the file path to the portrait sprite used for the card.</summary>
        public virtual string PortraitPath => string.Empty;
        /// <summary>Gets the canonical set of tags applied to the card.</summary>
        public virtual CardAspectSequence? CanonicalTags => null;
        /// <summary>Gets the canonical set of dynamic variables used by the card.</summary>
        public virtual CardVarSequence? CanonicalVars => null;
        /// <summary>
        /// Executes the card's effects.  In this stub implementation the
        /// asynchronous action completes immediately.  Override in derived
        /// classes to implement behaviour.
        /// </summary>
        public virtual Task OnPlay(MegaCrit.Sts2.Core.Models.Cards.CardPlayState state)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// Invoked when the card is upgraded.  Override in derived classes
        /// to modify cost or dynamic variables.
        /// </summary>
        public virtual void OnUpgrade()
        {
        }
        /// <summary>
        /// Determines whether the card should move to the discard pile after
        /// being played.  Override to implement mechanics like Load which
        /// prevent cards from being discarded immediately.
        /// </summary>
        public virtual bool ShouldMoveToDiscard() => true;
    }
}

namespace SEABOURNE.SEABOURNECode
{
    /// <summary>
    /// Additional tags unique to the Seabourne character.  These can be
    /// combined with standard card tags to drive mod‑specific mechanics.
    /// </summary>
    public enum SeabourneTag
    {
        Cannonball,
        GemCard
    }
}