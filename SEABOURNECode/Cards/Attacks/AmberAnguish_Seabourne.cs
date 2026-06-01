using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
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
    /// Common attack that acquires an Amber gem and deals heavy damage. Exhausts on play.
    /// </summary>
    public class AmberAnguish_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:AmberAnguish";
        public override string Name => "Amber Anguish";
        public override string Description => "Acquire an Amber and deal heavy damage. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/AmberAnguish";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(11, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire Amber gem and deal damage equal to DamageVar to the target
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage upgrade handled by dynamic variable
        }
    }
}