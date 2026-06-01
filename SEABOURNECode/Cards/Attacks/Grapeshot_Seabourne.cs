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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon cannonball that loads into the cannon, dealing damage and applying Vulnerable when fired.
    /// </summary>
    public class Grapeshot_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Grapeshot";
        public override string Name => "Grapeshot";
        public override string Description => "Load into the cannon. Deals damage and applies Vulnerable when fired.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Grapeshot";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(SeabourneTag.Cannonball);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // This card loads into the cannon; when fired it deals damage and applies 1 Vulnerable
            await Task.CompletedTask;
        }

        public override bool ShouldMoveToDiscard() => false;

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; vulnerable stacks remain constant
        }
    }
}