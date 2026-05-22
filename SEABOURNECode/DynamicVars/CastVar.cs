using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace SEABOURNE.SEABOURNECode.DynamicVars
{
    /// <summary>
    /// Dynamic variable to track the number of cards hooked by Cast in the Seabourne character.
    /// This variable appears in card descriptions as {Cast} or {Cast:diff()} to reflect
    /// how many cards will be hooked or reeled when the card is played or upgraded.  It
    /// inherits from DynamicVar to leverage the STS2 infrastructure for dynamic numbers
    /// displayed on cards.  The name is set to "Cast" by default, which aligns with
    /// localization keys defined in the mod's card descriptions.
    /// </summary>
    public class CastVar : DynamicVar
    {
        /// <summary>
        /// The default name used for this dynamic variable.  This must match the
        /// placeholder used in localization strings (e.g., {Cast}).
        /// </summary>
        public const string DefaultName = "Cast";

        /// <summary>
        /// Creates a new CastVar with the given base value.  The base value
        /// determines how many cards will be hooked when the card is played.
        /// </summary>
        /// <param name="baseValue">The base number of cards to hook.</param>
        public CastVar(decimal baseValue) : base(DefaultName, baseValue)
        {
            // Base constructor sets the Name and BaseValue fields
        }

        /// <summary>
        /// Creates a new CastVar with a default base value of zero.  The Name
        /// property is set automatically.
        /// </summary>
        public CastVar() : base(DefaultName, 0m)
        {
            // Default constructor uses zero as base value
        }
    }
}