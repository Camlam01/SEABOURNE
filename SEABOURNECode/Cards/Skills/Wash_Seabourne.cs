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
    /// Rare X-cost skill that allows the player to imbue and discard cards from the draw pile.
    /// </summary>
    public class Wash_Seabourne : SeabourneCard(int.MinValue, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Wash";
        public override string Name => "Wash";
        public override string Description => "Choose X cards from your draw pile, imbue them and discard them.";
        public override string PortraitPath => "SEABOURNE/Images/Wash";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: choose X+1 cards from the draw pile, apply Imbued to them and discard them
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version allows selecting one additional card (X+1)
        }
    }
}