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

namespace SEABOURNE.SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that grants all of your cards Imbued 1. This card is Ethereal, meaning it vanishes
    /// if not played. Upgrading does not change its cost or basic effect.
    /// </summary>
    public class SorcererForm_Seabourne : SeabourneCard(3, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:SorcererForm";
        public override string Name => "Sorcerer Form";
        public override string Description => "All cards gain Imbued 1. Ethereal.";
        public override string PortraitPath => "SEABOURNE/Images/SorcererForm";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Apply a power that gives all cards Imbued 1. This card should also gain the Ethereal keyword when appropriate.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No change on upgrade for now; the effect could be enhanced if needed.
        }
    }
}
