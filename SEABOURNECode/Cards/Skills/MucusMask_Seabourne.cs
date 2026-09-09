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
    /// Common skill that grants temporary Slippery stacks and permanently reduces its own Slippery.
    /// </summary>
    public class MucusMask_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:MucusMask";
        public override string Name => "Mucus Mask";
        public override string Description => "Gain Slippery this turn; this card loses Slippery permanently.";
        public override string PortraitPath => "SEABOURNE/Images/MucusMask";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply Slippery stacks to player (1 base, 2 upgraded) for this turn
            // and remove one permanent Slippery stack from this card for the remainder of the combat
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version applies 2 Slippery instead of 1
        }
    }
}