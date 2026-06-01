using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Entities.Cards;
using BaseLib.Abstracts;

namespace SEABOURNE.SEABOURNECode
{
    /// <summary>
    /// Utility functions for the Seabourne mod.  These helpers centralise
    /// commonly used operations such as creating card IDs, tag collections
    /// and variable sequences.  Use these methods rather than duplicating
    /// logic across individual cards or powers.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Creates a fully qualified identifier for a Seabourne asset.  All
        /// mod identifiers should be prefixed with "Seabourne:" to avoid
        /// collisions with other mods.  Pass the simple name to this method
        /// to obtain the correct ID.
        /// </summary>
        /// <param name="simpleName">The unqualified name.</param>
        /// <returns>A fully qualified identifier.</returns>
        public static string MakeId(string simpleName)
        {
            return $"Seabourne:{simpleName}";
        }

        /// <summary>
        /// Combines a series of <see cref="CardTag"/> values into a
        /// <see cref="CardAspectSequence"/>.  This helper wraps the
        /// <see cref="CardTagsProvider.Instance.From"/> call to simplify
        /// tag creation in cards and powers.
        /// </summary>
        /// <param name="tags">The tags to combine.</param>
        /// <returns>A sequence representing the provided tags.</returns>
        public static CardAspectSequence Tags(params CardTag[] tags)
        {
            return CardTagsProvider.Instance.From(tags);
        }

        /// <summary>
        /// Combines a series of <see cref="IDynamicVar"/> values into a
        /// <see cref="CardVarSequence"/>.  Use this helper instead of calling
        /// <see cref="CardVarsProvider.Instance.From"/> directly in each card.
        /// </summary>
        /// <param name="vars">The variables to combine.</param>
        /// <returns>A sequence representing the provided dynamic variables.</returns>
        public static CardVarSequence Vars(params IDynamicVar[] vars)
        {
            return CardVarsProvider.Instance.From(vars);
        }
    }
}