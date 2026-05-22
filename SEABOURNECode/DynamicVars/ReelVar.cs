using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace SEABOURNE.SEABOURNECode.DynamicVars
{
    /// <summary>
    /// Dynamic variable representing the number of cards reeled from the hook by
    /// Seabourne's Reel mechanic.  Cards that reel cards back into the hand can
    /// reference this variable using {Reel} or {Reel:diff()} in their descriptions.
    /// It extends DynamicVar to take advantage of the STS2 dynamic value system.
    /// </summary>
    public class ReelVar : DynamicVar
    {
        /// <summary>
        /// The default name used for this variable.  Must match the placeholder
        /// used in localization strings (e.g., {Reel}).
        /// </summary>
        public const string DefaultName = "Reel";

        /// <summary>
        /// Creates a new ReelVar with the specified base value.  The base value
        /// determines how many cards will be reeled when the card is played.
        /// </summary>
        /// <param name="baseValue">Number of cards reeled.</param>
        public ReelVar(decimal baseValue) : base(DefaultName, baseValue)
        {
            // Base constructor assigns Name and BaseValue
        }

        /// <summary>
        /// Creates a new ReelVar with a default base value of zero.
        /// </summary>
        public ReelVar() : base(DefaultName, 0m)
        {
            // Default constructor uses zero as base value
        }
    }
}