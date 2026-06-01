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
    // ------------------------------------------------------------------
    // Enumeration definitions
    //
    // The real Slay the Spire 2 API defines these enums in the
    // MegaCrit.Sts2.Core.Entities.Cards namespace.  When building this
    // mod without access to the game assemblies, these definitions are
    // provided here to satisfy compile‑time references in card files.
    // Should you compile against the actual game, remove these stub
    // definitions to avoid duplicate type errors.  Keeping the enums in
    // this separate namespace also prevents clashes with the versions in
    // Entities.Cards.

    /// <summary>
    /// Represents the category of a card.  Only the common categories used
    /// by the Seabourne mod are represented here.  Expand this enum if
    /// additional card types are required.
    /// </summary>
    public enum CardType
    {
        Attack,
        Skill,
        Power,
        Status,
        Curse
    }

    /// <summary>
    /// Represents the rarity tier of a card.  This stub includes the tiers
    /// referenced by the Seabourne mod.  Additional rarities can be added
    /// as needed for future content.
    /// </summary>
    public enum CardRarity
    {
        Basic,
        Common,
        Uncommon,
        Rare
    }

    /// <summary>
    /// Represents special tags applied to cards.  Tags can be used to
    /// categorise cards for mechanics like strike/defend bonuses or
    /// exhaust/innate behaviours.  Only a subset of tags needed by the
    /// Seabourne mod are defined here.  Add more values if your mod
    /// depends on additional tags.
    /// </summary>
    public enum CardTag
    {
        Strike,
        Defend,
        Exhaust,
        Innate
    }

    /// <summary>
    /// Specifies which creatures a card targets when played.  This enum
    /// mirrors the values of the TargetType enum used internally by the
    /// game.  Defining it here allows card definitions to compile without
    /// referencing the game assemblies.  If you compile against the real
    /// STS2 API, you may remove this stub.
    /// </summary>
    public enum CardTarget
    {
        None,
        Self,
        AnyEnemy,
        AllEnemies,
        RandomEnemy,
        AnyPlayer,
        AnyAlly,
        AllAllies
    }
}

namespace MegaCrit.Sts2.Core.Models.Cards
{
    // The enums CardType, CardRarity and CardTag are declared in
    // MegaCrit.Sts2.Core.Entities.Cards in this stub.  Do not import the
    // non‑existent Models.Cards.Enums namespace to avoid missing symbol errors.
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

        public CardAspectSequence From(params MegaCrit.Sts2.Core.Entities.Cards.CardTag[] tags)
        {
            // Accept tags defined in the Entities namespace.  No behaviour is
            // implemented here; the sequence merely serves as a placeholder.
            return new CardAspectSequence();
        }

        public CardAspectSequence From(params MegaCrit.Sts2.Core.Models.Cards.Enums.CardTag[] tags)
        {
            // Accept tags defined in the Models.Cards.Enums namespace.  This overload
            // allows callers to pass tags without importing the Entities namespace.
            return new CardAspectSequence();
        }

        public CardAspectSequence From(params SEABOURNE.SEABOURNECode.SeabourneTag[] tags)
        {
            // Accept custom Seabourne tags defined in the SEABOURNECode namespace.
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
    // ----------------------------------------------------------------------
    // NOTE: These enum definitions are provided solely so that the Seabourne mod
    // can compile in environments where the full Slay the Spire 2 API is not
    // available.  When building against the actual game, the real definitions
    // in MegaCrit.Sts2.Core.Entities.Cards will be used instead.  If you see
    // duplicate definition errors while linking against the game, remove
    // these stubs.

    // NOTE: CardType, CardRarity and CardTag enums are defined in the actual
    // Slay the Spire 2 API.  They are intentionally omitted from this stub
    // to prevent conflicts when building against the game.  If you
    // encounter missing type errors for these enums, ensure your code imports
    // MegaCrit.Sts2.Core.Entities.Cards.  The CardTarget enum below is not
    // provided by the base API; it exists solely so Seabourne card files
    // referring to CardTarget can compile.  It mirrors the values of the
    // TargetType enum used internally by the game.

    /// <summary>
    /// Specifies which creatures a card targets when played.  This stub
    /// mirrors the values of the TargetType enum in the real API to avoid
    /// compile errors in mod code.  If you are compiling against the
    /// game assemblies directly, you can safely ignore this enum.
    /// </summary>
    public enum CardTarget
    {
        None,
        Self,
        AnyEnemy,
        AllEnemies,
        RandomEnemy,
        AnyPlayer,
        AnyAlly,
        AllAllies
    }

    // ----------------------------------------------------------------------
    // Additional enumeration stubs
    //
    // The Slay the Spire 2 API defines several enums in this namespace (e.g.
    // CardType, CardRarity and CardTag).  Because the real assemblies are not
    // available in this build environment, we provide minimal definitions
    // here so that mod code referring to these types can compile.  If you
    // compile against the real game, remove these definitions to avoid
    // conflicts and rely on the official enums.

    /// <summary>
    /// Represents the category of a card.  Only the common categories used
    /// by the Seabourne mod are represented here.  Additional values may be
    /// added as needed to satisfy compile‑time references.
    /// </summary>
    public enum CardType
    {
        Attack,
        Skill,
        Power,
        Status,
        Curse
    }

    /// <summary>
    /// Represents the rarity tier of a card.  This stub includes the tiers
    /// referenced by the Seabourne mod.  Expand with other rarities if
    /// necessary for additional content.
    /// </summary>
    public enum CardRarity
    {
        Basic,
        Common,
        Uncommon,
        Rare
    }

    /// <summary>
    /// Represents special tags applied to cards.  Tags can be used to
    /// categorise cards for mechanics like strike/defend bonuses or
    /// exhaust/innate behaviours.  This stub defines only a few tags used
    /// within the Seabourne mod.  Additional tags can be added here to
    /// support further functionality.
    /// </summary>
    public enum CardTag
    {
        Strike,
        Defend,
        Exhaust,
        Innate
    }

    /// <summary>
    /// Placeholder runtime class for a card.  In the full API this manages
    /// upgrade state, enchantments and other runtime information.  Here it
    /// simply holds a reference to the underlying card model.
    /// </summary>
    public class CardRuntime
    {
        public MegaCrit.Sts2.Core.Models.CardModel CardModel { get; set; }
    }
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

    // ----------------------------------------------------------------------
    // Dynamic variable stubs
    //
    // The real STS2 API defines a number of dynamic variable types (e.g. DamageVar,
    // BlockVar, CastVar, ReelVar, CannonballVar and EnergyVar) that plug into
    // the localisation system and drive numeric text on cards.  To allow the
    // Seabourne mod to compile without the game assemblies present, we provide
    // minimal stand‑ins here.  Each dynamic var exposes a static factory
    // method returning a new instance.  No functional behaviour is implemented.

    public class DamageVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private DamageVar() { }
        public static DamageVar ForDamage(int baseValue, int upgradeValue)
        {
            return new DamageVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
    }

    public class BlockVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private BlockVar() { }
        public static BlockVar ForBlock(int baseValue, int upgradeValue)
        {
            return new BlockVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
    }

    public class CastVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private CastVar() { }
        public static CastVar ForCast(int baseValue, int upgradeValue)
        {
            return new CastVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
    }

    public class ReelVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private ReelVar() { }
        public static ReelVar ForReel(int baseValue, int upgradeValue)
        {
            return new ReelVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
    }

    public class CannonballVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private CannonballVar() { }
        public static CannonballVar ForCannonball(int baseValue, int upgradeValue)
        {
            return new CannonballVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
    }

    public class EnergyVar : IDynamicVar
    {
        public int BaseValue { get; set; }
        public int UpgradeValue { get; set; }
        private EnergyVar() { }
        public static EnergyVar ForEnergy(int baseValue, int upgradeValue)
        {
            return new EnergyVar { BaseValue = baseValue, UpgradeValue = upgradeValue };
        }
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
    // The enums are defined in MegaCrit.Sts2.Core.Entities.Cards in this stub.

    /// <summary>
    /// Minimal custom card model used for modding.  This stub defines the
    /// overridable members commonly used in card definitions.  It is not
    /// functional and should be replaced by the real game API when available.
    /// </summary>
    public abstract class CustomCardModel
    {
        /// <summary>
        /// Constructs a new card model with the specified cost, type, rarity and target.
        /// This constructor mirrors the signature provided by the real STS2 API and
        /// allows derived classes to pass these values when using the stubs.  The
        /// parameters are not stored or used by this stub implementation.
        /// </summary>
        protected CustomCardModel(int cost, MegaCrit.Sts2.Core.Entities.Cards.CardType type, MegaCrit.Sts2.Core.Entities.Cards.CardRarity rarity, MegaCrit.Sts2.Core.Entities.Cards.CardTarget target, bool showInCardLibrary = true, bool autoAdd = true)
        {
        }
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

// ----------------------------------------------------------------------
// Godot and character stubs
//
// Some classes below are referenced by the Seabourne mod but reside in the
// Godot engine or the STS2 API.  To allow compilation without those
// assemblies, we provide simplified stand‑ins here.  They do not implement
// any real functionality.

namespace Godot
{
    /// <summary>
    /// Minimal colour struct used by character models and UI.  The real
    /// implementation provides many utility methods; here we simply store
    /// three floats for RGB.  A constructor accepting a hex string is
    /// provided for convenience but does not parse the string.
    /// </summary>
    public struct Color
    {
        public float R { get; }
        public float G { get; }
        public float B { get; }
        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
        public Color(string hex)
        {
            R = 0f;
            G = 0f;
            B = 0f;
        }
    }
}

namespace MegaCrit.Sts2.Core.Entities.Characters
{
    /// <summary>
    /// Enumeration used to indicate the grammatical gender of a character.
    /// </summary>
    public enum CharacterGender
    {
        Masculine,
        Feminine,
        Neutral
    }
}

namespace MegaCrit.Sts2.Core.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Minimal base class for all models.  In the real API this would
    /// implement localisation and ID logic.  Here it is an empty class
    /// serving only as a common base type.
    /// </summary>
    public abstract class AbstractModel
    {
    }

    /// <summary>
    /// Placeholder card model.  In the real API this class exposes many
    /// properties and methods relating to cards.  Here it is empty so that
    /// card definitions can compile.
    /// </summary>
    public abstract class CardModel : AbstractModel
    {
    }

    /// <summary>
    /// Placeholder relic model.  In the real API this contains relic
    /// behaviour and localisation.  This stub is empty.
    /// </summary>
    public abstract class RelicModel : AbstractModel
    {
    }

    /// <summary>
    /// Placeholder potion model.  In the real API this contains potion
    /// behaviour and localisation.  This stub is empty.
    /// </summary>
    public abstract class PotionModel : AbstractModel
    {
    }

    /// <summary>
    /// Placeholder card pool model.  In the real API this class defines
    /// collections of cards available to a character.  Here we leave it
    /// non‑abstract so derived pools need not implement any members.
    /// </summary>
    public class CardPoolModel : AbstractModel
    {
    }

    /// <summary>
    /// Placeholder relic pool model.  Real implementations manage relic
    /// unlocks and distributions.  Left non‑abstract here.
    /// </summary>
    public class RelicPoolModel : AbstractModel
    {
    }

    /// <summary>
    /// Placeholder potion pool model.  Real implementations manage potion
    /// distributions.  Left non‑abstract here.
    /// </summary>
    public class PotionPoolModel : AbstractModel
    {
    }

    /// <summary>
    /// Static helper class used to retrieve model instances via generics in
    /// SeabourneCharacter.  The real API would return registered models from
    /// internal dictionaries.  Here we simply instantiate a new object of
    /// the requested type.  Only a subset of methods required by the
    /// Seabourne mod are implemented.
    /// </summary>
    public static class ModelDb
    {
        public static T Card<T>() where T : CardModel, new() => new T();
        public static T Relic<T>() where T : RelicModel, new() => new T();
        public static T CardPool<T>() where T : CardPoolModel, new() => new T();
        public static T RelicPool<T>() where T : RelicPoolModel, new() => new T();
        public static T PotionPool<T>() where T : PotionPoolModel, new() => new T();
    }
}

namespace MegaCrit.Sts2.Core.Models.Characters
{
    using System.Collections.Generic;
    using MegaCrit.Sts2.Core.Entities.Characters;
    using Godot;

    /// <summary>
    /// Minimal placeholder character model used by the Seabourne mod.  In the
    /// real API this class would provide many virtual and abstract members
    /// controlling character behaviour, visuals and interactions.  The
    /// SeabourneCharacter class derives from this stub when the game
    /// assemblies are unavailable.
    /// </summary>
    public abstract class PlaceholderCharacterModel : AbstractModel
    {
        public virtual int StartingHp => 70;
        public virtual int StartingGold => 99;
        // In the real API, characters provide a property named StartingEnergy
        // to indicate the base energy per turn.  Some earlier versions used
        // MaxEnergy; to support mods that override StartingEnergy, we expose
        // both properties.  By default they return the same value.
        public virtual int StartingEnergy => 3;
        public virtual int MaxEnergy => StartingEnergy;
        public virtual Color NameColor => new Color(1f, 1f, 1f);
        public virtual Color EnergyLabelOutlineColor => new Color(1f, 1f, 1f);
        public virtual Color MapDrawingColor => new Color(1f, 1f, 1f);
        public virtual CharacterGender Gender => CharacterGender.Masculine;
        public virtual string CustomCharacterSelectIconPath => string.Empty;
        public virtual string CustomCharacterSelectLockedIconPath => string.Empty;
        public virtual string CustomCharacterSelectBg => string.Empty;
        public virtual string CustomIconTexturePath => string.Empty;
        public virtual string CustomIconPath => string.Empty;
        public virtual string CustomMapMarkerPath => string.Empty;
        public virtual string CustomVisualPath => string.Empty;
        public virtual string CustomMerchantAnimPath => string.Empty;
        public virtual string CustomRestSiteAnimPath => string.Empty;
        public virtual string CustomEnergyCounterPath => string.Empty;
        public virtual string CharacterSelectSfx => string.Empty;
        public virtual IEnumerable<MegaCrit.Sts2.Core.Models.CardModel> StartingDeck => new List<MegaCrit.Sts2.Core.Models.CardModel>();
        public virtual IReadOnlyList<MegaCrit.Sts2.Core.Models.RelicModel> StartingRelics => new List<MegaCrit.Sts2.Core.Models.RelicModel>();
        public virtual IReadOnlyList<MegaCrit.Sts2.Core.Models.PotionModel> StartingPotions => new List<MegaCrit.Sts2.Core.Models.PotionModel>();
        public virtual MegaCrit.Sts2.Core.Models.CardPoolModel CardPool => new MegaCrit.Sts2.Core.Models.CardPoolModel();
        public virtual MegaCrit.Sts2.Core.Models.RelicPoolModel RelicPool => new MegaCrit.Sts2.Core.Models.RelicPoolModel();
        public virtual MegaCrit.Sts2.Core.Models.PotionPoolModel PotionPool => new MegaCrit.Sts2.Core.Models.PotionPoolModel();
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