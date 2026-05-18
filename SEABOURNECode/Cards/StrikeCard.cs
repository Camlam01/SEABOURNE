using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// A basic attack card for the Seabourne character.  Deals damage
    /// equal to its damage variable to a single enemy.  Upgrades increase
    /// the damage by 3.
    /// </summary>
    public sealed class StrikeCard : SeabourneCard
    {
        public StrikeCard() : base(1, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
        {
        }

        protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[] { new DamageVar(6m, ValueProp.Move) };

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // If no target was selected, do nothing
            if (play.Target == null)
                return;
            // Directly call the attack command with the primary damage value
            await DamageCmd.Attack(PrimaryDamage.IntValue)
                .FromCard(this)
                .Targeting(play.Target)
                .Execute(choiceContext);
        }

        protected override void OnUpgrade()
        {
            // Increase damage by 3 when upgraded
            PrimaryDamage.UpgradeValueBy(3m);
        }
    }
}