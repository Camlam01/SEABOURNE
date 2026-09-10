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
    /// Rare power that allows the player to choose any gem at the start of their turn and acquire it. Upgrading
    /// reduces the energy cost, making it free to play.
    /// </summary>
    public class XMarksTheSpot_Seabourne() : SeabourneCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:XMarksTheSpot";
        public override string Name => "X Marks the Spot";
        public override string Description => "At the start of your turn choose any Gem and acquire it.";
        public override string PortraitPath => "SEABOURNE/Images/XMarksTheSpot";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Apply a power that lets the player choose any gem at the start of their turn and acquire it.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}