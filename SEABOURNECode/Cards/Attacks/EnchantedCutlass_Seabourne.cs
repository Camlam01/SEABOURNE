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
    /// Rare attack dealing heavy damage and granting multiple Imbued stacks.
    /// </summary>
    public class EnchantedCutlass_Seabourne : SeabourneCard(3, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:EnchantedCutlass";
        public override string Name => "Enchanted Cutlass";
        public override string Description => "Deal heavy damage and gain Imbued.";
        public override string PortraitPath => "SEABOURNE/Images/EnchantedCutlass";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(25, 0)
        );

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