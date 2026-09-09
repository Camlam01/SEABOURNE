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
    /// Uncommon skill that grants random gems. Applies Wet. Upgraded version increases the number of gems.
    /// </summary>
    public class LuckOfTheSea_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:LuckOfTheSea";
        public override string Name => "Luck of the Sea";
        public override string Description => "Gain a random treasure. Wet.";
        public override string PortraitPath => "SEABOURNE/Images/LuckOfTheSea";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: gain 1 random gem (2 when upgraded) and apply Wet to this card
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Number of treasures gained increases when upgraded
        }
    }
}