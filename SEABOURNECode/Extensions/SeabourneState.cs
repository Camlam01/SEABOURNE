namespace SEABOURNE.SEABOURNECode.Extensions
{
    /// <summary>
    /// Placeholder state class for Seabourne-specific mechanics.  The
    /// Slay the Spire 2 framework allows mods to attach arbitrary state
    /// information to characters.  Use this class to track data such as
    /// the current cast depth, loaded cannonballs, or other per-character
    /// values.  Additional properties and methods can be added when the
    /// underlying mechanics are implemented.
    /// </summary>
    public class SeabourneState
    {
        /// <summary>
        /// Gets or sets the current cast stacks.  When cast is applied by
        /// cards, this value increases; reeling cards will consume it.
        /// </summary>
        public int CastStacks { get; set; }

        /// <summary>
        /// Gets or sets the number of loaded cannonballs.  Cards that load
        /// into the cannon should increment this, and cards that fire the
        /// cannon should decrement it.
        /// </summary>
        public int LoadedCannonballs { get; set; }

        /// <summary>
        /// Gets or sets the current reel stacks.  This can be used to
        /// determine how many cards will be reeled when a reel effect
        /// triggers.
        /// </summary>
        public int ReelStacks { get; set; }
    }
}