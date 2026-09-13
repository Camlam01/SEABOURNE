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
using MegaCrit.Sts2.Core.Models.Powers;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon cannonball that loads into the cannon, dealing damage and applying Vulnerable when fired.
    /// </summary>
    public class Grapeshot_Seabourne() : CannonballCard(0, CardRarity.Uncommon)
    {
        public const string ID = "Seabourne:Grapeshot";
        public override string Name => "Grapeshot";
        public override string Description => "Load. When fired, deal {Damage:diff()} damage and apply 1 Vulnerable.";
        public override string PortraitPath => "SEABOURNE/Images/Grapeshot";
        protected override HashSet<CardTag> CanonicalTags => [SeabourneTags.Cannonball];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(5, ValueProp.Move).WithUpgrade(5)
        ];
        protected override async Task OnFire(PlayerChoiceContext choiceContext, CardPlay play)
        {
            await base.OnFire(choiceContext, play);
            if (play.Target is not null && play.Target.IsAlive)
            {
                await PowerCmd.Apply<VulnerablePower>(
                    [play.Target], 1m, Owner.Creature, this, false);
            }
        }
protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; vulnerable stacks remain constant
        }
    }
}
