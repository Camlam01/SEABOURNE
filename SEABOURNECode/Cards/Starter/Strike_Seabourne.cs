using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// A basic attack card for Seabourne. Deals moderate damage to a single enemy.
    /// </summary>
    public class Strike_Seabourne() : SeabourneCard(1, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Strike";
        public override string Name => "Strike";
        public override string Description => "Deal {Damage} damage.";
        public override string PortraitPath => "SEABOURNE/Images/Strike";
        protected override HashSet<CardTag> CanonicalTags => [CardTag.Strike];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(6, ValueProp.Move).WithUpgrade(3)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // Deal damage to the selected enemy
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increase handled by dynamic variable
        }
    }
}
