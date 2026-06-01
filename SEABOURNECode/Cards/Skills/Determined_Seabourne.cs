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
    /// Uncommon skill that empowers enemies and grants the player Slippery for the turn.
    /// </summary>
    public class Determined_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Determined";
        public override string Name => "Determined";
        public override string Description => "Give all enemies Strength. Gain Slippery.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/Determined";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: give all enemies 3 Strength and grant the player 1 Slippery for this turn
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Slippery gained may increase when upgraded; implement in OnPlay
        }
    }
}