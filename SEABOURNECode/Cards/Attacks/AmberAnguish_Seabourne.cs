using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
    using SEABOURNE.SEABOURNECode.Cards;
    using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that acquires an Amber gem and deals heavy damage. Exhausts on play.
    /// </summary>
    public class AmberAnguish_Seabourne : SeabourneCard(2, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:AmberAnguish";
        public override string Name => "Amber Anguish";
        public override string Description => "Acquire an Amber and deal heavy damage. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/AmberAnguish";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(11, ValueProp.Move).WithUpgrade(3)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire Amber gem and deal damage equal to DamageVar to the target
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage upgrade handled by dynamic variable
        }
    }
}