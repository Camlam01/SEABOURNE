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
    /// Uncommon cannonball attack that loads into the cannon and deals damage plus extra energy when fired.
    /// </summary>
    public class Vimshot_Seabourne() : SeabourneCard(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Vimshot";
        public override string Name => "Vimshot";
        public override string Description => "Load into the cannon. Deals damage and adds energy when fired.";
        public override string PortraitPath => "SEABOURNE/Images/Vimshot";
        protected override HashSet<CardTag> CanonicalTags => [SeabourneTags.Cannonball];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(15, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // The card loads into the cannon; actual damage and energy gain are handled when the cannon fires.
            await Task.CompletedTask;
        }
protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Extra energy on firing increases by 1; implement in cannon firing logic
        }
    }
}