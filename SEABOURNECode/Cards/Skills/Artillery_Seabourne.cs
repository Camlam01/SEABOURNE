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
    public class Artillery_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Artillery";
        public override string Name => "Artillery";
        public override string Description => "Add random cannonballs to your hand. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Artillery";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: add 5 random cannonball cards to the player's hand
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version may increase variety or number; implement in OnPlay
        }
    }
}