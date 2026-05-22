using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace SEABOURNE.SEABOURNECode.DynamicVars
{
    /// <summary>
    /// Dynamic variable to track the number of loaded cannonballs for the Seabourne's
    /// Cannon mechanic.  Cards that load or consume cannonballs reference this variable
    /// in their descriptions (e.g. {Cannonballs} or {Cannonballs:diff()}).  The base
    /// value represents how many cannonballs are loaded or will be loaded when the card
    /// is played.  Like other dynamic variables, this inherits from DynamicVar so
    /// upgrading the card will display the difference in values.
    /// </summary>
    public class CannonballVar : DynamicVar
    {
        /// <summary>
        /// Default name for this variable.  Must match the localization key used in
        /// card descriptions (e.g. {Cannonballs}).
        /// </summary>
        public const string DefaultName = "Cannonballs";

        /// <summary>
        /// Initializes a new instance of the CannonballVar with the specified
        /// base value.  This sets the Name property accordingly.
        /// </summary>
        /// <param name="baseValue">The base number of cannonballs to load.</param>
        public CannonballVar(decimal baseValue) : base(baseValue)
        {
            this.Name = DefaultName;
        }

        /// <summary>
        /// Initializes a new instance of the CannonballVar with a base value of zero.
        /// </summary>
        public CannonballVar() : base()
        {
            this.Name = DefaultName;
        }
    }
}