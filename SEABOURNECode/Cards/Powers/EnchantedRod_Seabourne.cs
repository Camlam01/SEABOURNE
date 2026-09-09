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
    /// Rare power that causes the first card reeled each turn to become imbued without consuming gem charges.
    /// When upgraded the effect applies to the first two cards reeled each turn.
    /// </summary>
    public class EnchantedRod_Seabourne : SeabourneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:EnchantedRod";
        public override string Name => "Enchanted Rod";
        public override string Description => "The first card reeled each turn is imbued without using gem charges.";
        public override string PortraitPath => "SEABOURNE/Images/EnchantedRod";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Apply a power that imbues the first (or first two when upgraded) reeled card(s) without consuming gem charges.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: imbue the first two cards reeled each turn. No cost change.
        }
    }
}
