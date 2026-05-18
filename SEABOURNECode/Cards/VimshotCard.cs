using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// Vimshot is an uncommon Seabourne attack that refunds energy when played
    /// and deals moderate damage.  Upgrades increase its damage.
    /// </summary>
    public sealed class VimshotCard : SeabourneCard
    {
        public VimshotCard() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
        {
        }

        /// <summary>
        /// Vimshot refunds 1 energy when played.
        /// </summary>
        public override int EnergyGain => 1;

        protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[] { new DamageVar(15m, ValueProp.Move) };

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // If no target, do nothing
            if (play.Target == null)
                return;
            // Deal damage to the target
            await DamageCmd.Attack(PrimaryDamage.IntValue)
                .FromCard(this)
                .Targeting(play.Target)
                .Execute(choiceContext);
        }

        protected override void OnUpgrade()
        {
            // Increase damage by 2 when upgraded
            PrimaryDamage.UpgradeValueBy(2m);
        }
    }
}