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
    /// Uncommon cannonball attack that loads into the cannon and deals damage plus extra energy when fired.
    /// </summary>
    public class Vimshot_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Vimshot";
        public override string Name => "Vimshot";
        public override string Description => "Load into the cannon. Deals damage and adds energy when fired.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Vimshot";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(SeabourneTag.Cannonball);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(15, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // The card loads into the cannon; actual damage and energy gain are handled when the cannon fires.
            await Task.CompletedTask;
        }

        public override bool ShouldMoveToDiscard() => false;

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Extra energy on firing increases by 1; implement in cannon firing logic
        }
    }
}