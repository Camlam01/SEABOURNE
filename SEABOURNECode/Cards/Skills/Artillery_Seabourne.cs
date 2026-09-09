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
    /// Rare skill that adds several random cannonball cards to the player's hand. Exhausts on play.
    /// </summary>
    public class Artillery_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Artillery";
        public override string Name => "Artillery";
        public override string Description => "Add random cannonballs to your hand. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/Artillery";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: add 5 random cannonball cards to the player's hand
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version may increase variety or number; implement in OnPlay
        }
    }
}