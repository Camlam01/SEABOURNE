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
    /// Uncommon cannonball that loads into the cannon for a powerful damage payload.
    /// </summary>
    public class Roundshot_Seabourne() : CannonballCard(2, CardRarity.Uncommon)
    {
        public const string ID = "Seabourne:Roundshot";
        public override string Name => "Roundshot";
        public override string Description => "Load. When fired, deal {Damage:diff()} damage.";
        public override string PortraitPath => "SEABOURNE/Images/Roundshot";
        protected override HashSet<CardTag> CanonicalTags => [SeabourneTags.Cannonball];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(30, ValueProp.Move).WithUpgrade(10)
        ];
protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}
