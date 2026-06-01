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

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that acquires an Opal gem and reels the hooked card. Exhausts on play.
    /// </summary>
    public class OceanicOpal_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:OceanicOpal";
        public override string Name => "Oceanic Opal";
        public override string Description => "Acquire an Opal and reel the hooked card. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/OceanicOpal";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire Opal gem and reel cards according to current cast
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0
            EnergyCost.UpgradeBy(-1);
        }
    }
}