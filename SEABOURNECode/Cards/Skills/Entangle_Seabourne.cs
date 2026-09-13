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
    /// Common skill that applies Cast to the player and Weak to all enemies.
    /// </summary>
    public class Entangle_Seabourne() : SeabourneCard(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:Entangle";
        public override string Name => "Entangle";
        public override string Description => "Cast and apply Weak to all enemies.";
        public override string PortraitPath => "SEABOURNE/Images/Entangle";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new CastVar(2).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply Cast to player and apply Weak to all enemies (1, upgraded 2)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // When upgraded the Weak applied becomes 2; this should be handled within the OnPlay implementation.
        }
    }
}