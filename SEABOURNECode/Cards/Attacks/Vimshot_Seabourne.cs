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
using SEABOURNE.SEABOURNECode.Cannon;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon cannonball attack that loads into the cannon and deals damage plus extra energy when fired.
    /// </summary>
    public class Vimshot_Seabourne() : CannonballCard(1, CardRarity.Uncommon)
    {
        public const string ID = "Seabourne:Vimshot";
        public override string Name => "Vimshot";
        public override string Description => IsUpgraded
            ? "Load. When fired, deal {Damage:diff()} damage and gain 2 Energy."
            : "Load. When fired, deal {Damage:diff()} damage and gain 1 Energy.";
        public override string PortraitPath => "SEABOURNE/Images/Vimshot";
        protected override HashSet<CardTag> CanonicalTags => [SeabourneTags.Cannonball];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(15, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnFire(PlayerChoiceContext choiceContext, CardPlay play)
        {
            await base.OnFire(choiceContext, play);
            await PlayerCmd.GainEnergy(IsUpgraded ? 2m : 1m, Owner);
        }
protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Extra energy on firing increases by 1; implement in cannon firing logic
        }
    }
}
