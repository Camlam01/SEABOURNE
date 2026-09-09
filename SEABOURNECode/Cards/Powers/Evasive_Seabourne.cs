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
    /// Rare power that grants Slippery stacks but prevents the player from gaining block. Upgrades increase
    /// the number of Slippery stacks granted.
    /// </summary>
    public class Evasive_Seabourne : SeabourneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Evasive";
        public override string Name => "Evasive";
        public override string Description => "Gain Slippery. Cannot gain block.";
        public override string PortraitPath => "SEABOURNE/Images/Evasive";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Apply a power that gives the player Slippery (5 or 7 when upgraded) and prevents them from gaining block.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: increase the amount of Slippery granted from 5 to 7. No cost change.
        }
    }
}
