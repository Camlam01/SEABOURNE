using BaseLib.Abstracts;
using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.Cards;

namespace SEABOURNE.SEABOURNECode.Enums
{
    /// <summary>
    /// Defines custom card tags for the Seabourne mod. Tags are used to group cards
    /// with shared characteristics such as cannonballs or gem cards. Registering tags
    /// via <see cref="CustomEnumAttribute"/> ensures they are available before any
    /// card definitions reference them.
    /// </summary>
    public static class SeabourneTags
    {
        /// <summary>
        /// Tag assigned to cannonball cards. Cannonball cards are loaded into the
        /// cannon and fire later rather than resolving immediately when played.
        /// </summary>
        [CustomEnum]
        public static CardTag Cannonball;

        /// <summary>
        /// Tag assigned to gem cards. Cards with this tag interact with the gem
        /// system, such as granting or consuming gem charges.
        /// </summary>
        [CustomEnum]
        public static CardTag GemCard;
    }

    /// <summary>
    /// Defines custom keywords for the Seabourne mod. Keywords provide additional
    /// semantics to cards and are automatically localized via the mod's
    /// localization files (e.g., cards and keywords JSON). The
    /// <see cref="CustomEnumAttribute"/> registers the keyword so that it can
    /// appear in card descriptions. <see cref="KeywordProperties"/> is used
    /// here to ensure the keyword appears before standard keywords in the
    /// description list.
    /// </summary>
    public static class SeabourneKeywords
    {
        [CustomEnum("CAST")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Cast;

        [CustomEnum("REEL")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Reel;

        [CustomEnum("WET")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Wet;

        [CustomEnum("WATERWALL")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Waterwall;

        [CustomEnum("TRANCE")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Trance;

        [CustomEnum("IMBUED")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Imbued;

        [CustomEnum("UNIMBUED")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Unimbued;

        [CustomEnum("GEM")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Gem;

        [CustomEnum("GEM_SLOT")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword GemSlot;

        [CustomEnum("CANNON")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Cannon;

        [CustomEnum("LOAD")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Load;

        [CustomEnum("SLIPPERY")]
        [KeywordProperties(AutoKeywordPosition.Before)]
        public static CardKeyword Slippery;
    }
}