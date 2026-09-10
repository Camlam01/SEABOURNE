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
    /// Common skill that adds a number of Cannonball cards to the player's hand. Exhausts on play.
    /// </summary>
    public class StockUp_Seabourne() : SeabourneCard(0, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:StockUp";
        public override string Name => "Stock Up";
        public override string Description => "Create Cannonball cards. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/StockUp";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: create 2 Cannonball cards (3 when upgraded) and add them to the player's hand
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; number of cannonballs should increase from 2 to 3 when upgraded.
        }
    }
}