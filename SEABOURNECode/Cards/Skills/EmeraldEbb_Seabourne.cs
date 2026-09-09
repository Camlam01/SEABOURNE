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
    /// Common skill that acquires an Emerald gem and grants Waterwall. Exhausts on play.
    /// </summary>
    public class EmeraldEbb_Seabourne : SeabourneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:EmeraldEbb";
        public override string Name => "Emerald Ebb";
        public override string Description => "Acquire an Emerald and gain Waterwall. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/EmeraldEbb";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire Emerald gem and apply Waterwall stacks (base 7, upgrade 9)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; waterwall amount should increase when upgraded.
        }
    }
}