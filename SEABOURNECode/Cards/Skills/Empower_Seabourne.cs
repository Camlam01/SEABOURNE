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
    /// Uncommon skill that applies Trance to an enemy at the cost of giving them Strength.
    /// </summary>
    public class Empower_Seabourne : SeabourneCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Empower";
        public override string Name => "Empower";
        public override string Description => "Apply Trance but give the enemy Strength.";
        public override string PortraitPath => "SEABOURNE/Images/Empower";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply 5 (6 when upgraded) Trance to the target and give it 3 Strength
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Trance amount increases on upgrade
        }
    }
}