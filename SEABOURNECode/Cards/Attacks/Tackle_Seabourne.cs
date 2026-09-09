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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that strikes the target multiple times for small damage. Upgraded hits one additional time.
    /// </summary>
    public class Tackle_Seabourne : SeabourneCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Tackle";
        public override string Name => "Tackle";
        public override string Description => "Deal small damage multiple times.";
        public override string PortraitPath => "SEABOURNE/Images/Tackle";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(3, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: hit the target multiple times (2 times base, 3 times upgraded) dealing DamageVar damage each time
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No variable values change; number of hits increases in OnPlay
        }
    }
}