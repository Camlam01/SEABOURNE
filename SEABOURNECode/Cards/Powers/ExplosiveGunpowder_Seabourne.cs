using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that causes cannonballs to deal double damage and exhausts itself after use.
    /// </summary>
    public class ExplosiveGunpowder_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:ExplosiveGunpowder";
        public override string Name => "Explosive Gunpowder";
        public override string Description => "Cannonballs deal double damage. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/ExplosiveGunpowder";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that doubles cannonball damage and ensure this card exhausts
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No upgrade changes; effect remains the same
        }
    }
}