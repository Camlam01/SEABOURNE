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

namespace SEABOURNE.SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that grants Waterwall and reflects deflected damage back at enemies.
    /// </summary>
    public class Torrents_Seabourne : SeabourneCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:Torrents";
        public override string Name => "Torrents";
        public override string Description => "Gain Waterwall. When an attack is deflected, return the damage to the enemy.";
        public override string PortraitPath => "SEABOURNE/Images/Torrents";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new BlockVar(6, ValueProp.Move).WithUpgrade(2)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply a power that grants BlockVar Waterwall and reflects any deflected damage back at attackers
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Waterwall amount increases via dynamic variable
        }
    }
}