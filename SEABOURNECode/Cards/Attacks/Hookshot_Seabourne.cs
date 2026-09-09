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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that fires the cannon and reloads any cannonballs that were fired. When upgraded
    /// the energy cost is reduced.
    /// </summary>
    public class Hookshot_Seabourne : SeabourneCard(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Hookshot";
        public override string Name => "Hookshot";
        public override string Description => "Fire the cannon and reload all fired cannonballs.";
        public override string PortraitPath => "SEABOURNE/Images/Hookshot";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Fire the cannon at the target and then reload all previously fired cannonballs into the cannon.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}