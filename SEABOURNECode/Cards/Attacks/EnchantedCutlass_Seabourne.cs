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
    /// Rare attack dealing heavy damage and granting multiple Imbued stacks.
    /// </summary>
    public class EnchantedCutlass_Seabourne : SeabourneCard(3, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:EnchantedCutlass";
        public override string Name => "Enchanted Cutlass";
        public override string Description => "Deal heavy damage and gain Imbued.";
        public override string PortraitPath => "SEABOURNE/Images/EnchantedCutlass";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(25, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: deal DamageVar damage to the target and apply 2 Imbued (3 when upgraded) to this card
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Increase imbued stacks on upgrade; damage remains constant
        }
    }
}