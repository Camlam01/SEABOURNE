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
    /// Uncommon attack that deals damage, applies Vulnerable and has the Imbued modifier.
    /// </summary>
    public class SoulStab_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:SoulStab";
        public override string Name => "Soul Stab";
        public override string Description => "Deal damage and apply Vulnerable. Imbued.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/SoulStab";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage, apply 1 Vulnerable and apply 1 Imbued to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; imbued stacks may increase to 1 (2) if necessary
        }
    }
}