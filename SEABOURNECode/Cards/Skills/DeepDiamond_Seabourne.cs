using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using SEABOURNE.SEABOURNECode.DynamicVars;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that acquires a Diamond gem and grants Cast stacks. Exhausts on play.
    /// </summary>
    public class DeepDiamond_Seabourne() : SeabourneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:DeepDiamond";
        public override string Name => "Deep Diamond";
        public override string Description => "Acquire a Diamond and gain Cast. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/DeepDiamond";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new CastVar(3).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire Diamond gem and grant Cast equal to dynamic variable
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1
            EnergyCost.UpgradeBy(-1);
        }
    }
}