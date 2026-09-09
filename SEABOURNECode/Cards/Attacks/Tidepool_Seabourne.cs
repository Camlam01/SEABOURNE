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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that deals a small amount of damage and grants Waterwall. It applies Weak and Vulnerable
    /// to all enemies and creates a copy of itself in the discard pile. This card has the Wet keyword so
    /// that it is played automatically when reeled. Upgrades increase the numbers slightly.
    /// </summary>
    public class Tidepool_Seabourne : SeabourneCard(3, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:Tidepool";
        public override string Name => "Tidepool";
        public override string Description => "Deal damage, gain Waterwall, apply Weak and Vulnerable to all enemies and add a copy to your discard pile. Wet.";
        public override string PortraitPath => "SEABOURNE/Images/Tidepool";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(5, ValueProp.Move).WithUpgrade(1),
            new BlockVar(5, ValueProp.Move).WithUpgrade(1)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Deal DamageVar damage to all enemies, gain BlockVar Waterwall stacks, apply 1 Weak and 1 Vulnerable to all enemies,
            // then create a copy of this card in the discard pile. This card should have the Wet keyword so it is automatically played when reeled.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variables handle damage and block upgrades; cost remains unchanged.
        }
    }
}