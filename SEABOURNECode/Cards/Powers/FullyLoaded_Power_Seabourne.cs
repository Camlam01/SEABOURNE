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
    /// Rare power that causes the cannon to automatically fire at the start of each turn. This card has
    /// the Wet keyword so that it is played automatically when reeled. Upgrading reduces its cost.
    /// </summary>
    public class FullyLoaded_Power_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:FullyLoaded_Power";
        public override string Name => "Fully Loaded";
        public override string Description => "At the start of each turn, fire the cannon.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/FullyLoaded_Power";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Apply a power that fires the cannon automatically at the start of each turn.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}
