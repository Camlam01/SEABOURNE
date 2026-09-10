using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Enums;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
    using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common cannonball attack card. This card has the Load keyword, meaning it loads into the cannon instead of resolving
    /// immediately. When fired, it deals damage based on the dynamic variable.
    /// </summary>
    public class Cannonball_Seabourne() : SeabourneCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Cannonball";
        public override string Name => "Cannonball";
        public override string Description => "Load into the cannon. Deals damage when fired.";
        public override string PortraitPath => "SEABOURNE/Images/Cannonball";
        protected override HashSet<CardTag> CanonicalTags => [SeabourneTags.Cannonball];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(15, ValueProp.Move).WithUpgrade(5)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // Cannonballs do not resolve on play; they instead load into the cannon. The cannon manager handles damage when fired.
            await Task.CompletedTask;
        }
protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; cost remains the same.
        }
    }
}