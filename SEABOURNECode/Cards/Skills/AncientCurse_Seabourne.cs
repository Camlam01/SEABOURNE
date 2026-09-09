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

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that applies Vulnerable and Weak to all enemies and has the Imbued modifier.
    /// </summary>
    public class AncientCurse_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:AncientCurse";
        public override string Name => "Ancient Curse";
        public override string Description => "Apply Vulnerable and Weak to all enemies. Imbued.";
        public override string PortraitPath => "SEABOURNE/Images/AncientCurse";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply 1 Vulnerable and 1 Weak to all enemies (2 of each when upgraded) and apply Imbued stacks to this card
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Imbued stacks increase from 1 to 2 when upgraded
        }
    }
}