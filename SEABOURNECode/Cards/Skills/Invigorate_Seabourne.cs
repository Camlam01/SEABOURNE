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
    /// Common skill that recharges all of the player's gems. It exhausts when played.
    /// </summary>
    public class Invigorate_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:Invigorate";
        public override string Name => "Invigorate";
        public override string Description => "Recharge your gem treasures. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/Invigorate";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: recharge all gem slots so they are ready for the next enhancement
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0
            EnergyCost.UpgradeBy(-1);
        }
    }
}
