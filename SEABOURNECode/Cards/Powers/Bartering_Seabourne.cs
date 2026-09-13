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
    /// Rare power that removes all gems and grants gold for each gem removed. Upgrades increase the
    /// amount of gold gained. This represents selling your treasures for money.
    /// </summary>
    public class Bartering_Seabourne() : SeabourneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Bartering";
        public override string Name => "Bartering";
        public override string Description => "Remove all gems, gain 15 gold for each gem removed.";
        public override string PortraitPath => "SEABOURNE/Images/Bartering";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Remove all gems from the player and grant 15 gold per gem removed (25 gold when upgraded).
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: increase gold gained per gem from 15 to 25. No cost change.
        }
    }
}
