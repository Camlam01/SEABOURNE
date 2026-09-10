using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Relics
{
    /// <summary>
    /// Temporary placeholder for the future Seabourne starter relic.
    /// The character currently uses Burning Blood while the custom relic
    /// behaviour is migrated. Defining the current required rarity keeps this
    /// model compile-safe without prematurely registering unfinished content.
    /// </summary>
    public class SeabourneStarterRelic : RelicModel
    {
        public override RelicRarity Rarity => RelicRarity.Starter;
    }
}
