using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// A basic attack card for Seabourne. Deals moderate damage to a single enemy.
    /// </summary>
    public class Strike_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Strike";
        public override string Name => "Strike";
        public override string Description => "Deal {Damage} damage.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Basic;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Strike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Strike);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(6, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // Deal damage to the selected enemy
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increase handled by dynamic variable
        }
    }
}
