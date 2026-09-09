using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.DynamicVars;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that grants Cast and deals damage.
    /// </summary>
    public class RodRam_Seabourne : SeabourneCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:RodRam";
        public override string Name => "Rod Ram";
        public override string Description => "Cast and deal damage.";
        public override string PortraitPath => "SEABOURNE/Images/RodRam";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new CastVar(2).WithUpgrade(0),
            new DamageVar(5, ValueProp.Move).WithUpgrade(2)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply CastVar amount of Cast then deal DamageVar damage to the target
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases automatically; Cast stays constant
        }
    }
}