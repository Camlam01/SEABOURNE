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
    /// Uncommon skill that applies Trance to an enemy and applies Wet to the card. Upgraded version increases Trance amount.
    /// </summary>
    public class SirensScreech_Seabourne : SeabourneCard(3, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:SirensScreech";
        public override string Name => "Siren's Screech";
        public override string Description => "Apply Trance to an enemy. Wet.";
        public override string PortraitPath => "SEABOURNE/Images/SirensScreech";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply Trance (3 base, 4 upgraded) to the targeted enemy and apply Wet to this card
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Trance amount increases when upgraded
        }
    }
}