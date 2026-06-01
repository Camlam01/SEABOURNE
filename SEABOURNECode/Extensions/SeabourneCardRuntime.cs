using MegaCrit.Sts2.Core.Entities.Cards;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="CardRuntime"/> to provide
    /// Seabourne-specific behaviour.  These helpers allow runtime
    /// inspection of Seabourne cards without leaking implementation
    /// details into other parts of the mod.  The methods provided here
    /// should be considered temporary stubs until more complex behaviour
    /// is required.
    /// </summary>
    public static class SeabourneCardRuntime
    {
        /// <summary>
        /// Determines whether the runtime instance wraps a Seabourne card.
        /// </summary>
        /// <param name="runtime">The runtime instance to check.</param>
        /// <returns><c>true</c> if the underlying model derives from
        /// <see cref="SeabourneCard"/>; otherwise <c>false</c>.</returns>
        public static bool IsSeabourneCard(this CardRuntime runtime)
        {
            return runtime?.CardModel is SeabourneCard;
        }

        /// <summary>
        /// Placeholder method for checking if a card should load into the
        /// cannon rather than moving to the discard pile.  Actual logic
        /// should be implemented once the cannon mechanic is fully
        /// modelled.
        /// </summary>
        /// <param name="runtime">The runtime instance.</param>
        /// <returns>Always returns <c>false</c> until implemented.</returns>
        public static bool ShouldLoadIntoCannon(this CardRuntime runtime)
        {
            // TODO: implement cannon loading logic based on card tags or
            // model properties.  For now this simply returns false.
            return false;
        }
    }
}