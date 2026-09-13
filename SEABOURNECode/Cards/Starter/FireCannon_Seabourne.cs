using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.ValueProps;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;
using SEABOURNE.SEABOURNECode.Cannon;

namespace SEABOURNE.SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Starter attack which simply fires the Seabourne's cannon. When upgraded the cost is reduced by one.
    /// </summary>
    public class FireCannon_Seabourne() : SeabourneCard(2, CardType.Attack, CardRarity.Basic, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:FireCannon";
        public override string Name => "Fire Cannon";
        public override string Description => "Fire all loaded Cannonballs at an enemy. If empty, deal {Damage:diff()} damage to ALL enemies.";
        public override string PortraitPath => "SEABOURNE/Images/FireCannon";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(6m, ValueProp.Move)];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            if (CannonCmd.Loaded(Owner).Count > 0)
            {
                await CannonCmd.Fire(choiceContext, Owner, play.Target);
                return;
            }

            await DamageCmd.Attack(DynamicVars.Damage.BaseValue)
                .FromCard(this)
                .TargetingAllOpponents(CombatState!)
                .WithHitFx("vfx/vfx_attack_fire")
                .Execute(choiceContext);
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}
