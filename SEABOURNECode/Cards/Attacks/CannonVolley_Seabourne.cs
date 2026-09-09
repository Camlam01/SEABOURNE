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
    using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon attack that fires the cannon, increasing damage for each consecutive cannonball.
    /// </summary>
    public class CannonVolley_Seabourne : SeabourneCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:CannonVolley";
        public override string Name => "Cannon Volley";
        public override string Description => "Fire the cannon; each consecutive cannonball deals increased damage.";
        public override string PortraitPath => "SEABOURNE/Images/CannonVolley";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: fire the cannon; implement ramping damage (each cannonball deals 20% more damage than the previous)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change or dynamic variables; behaviour may remain constant
        }
    }
}