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
    /// Rare skill that imbues a chosen card in hand. Exhausts on play.
    /// </summary>
    public class Sorcery_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Sorcery";
        public override string Name => "Sorcery";
        public override string Description => "Add Imbued to a card in your hand. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/Sorcery";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: select a card in hand and apply Imbued 1 to it
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