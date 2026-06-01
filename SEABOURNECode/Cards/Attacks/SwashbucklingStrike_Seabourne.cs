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
    /// Common attack dealing substantial damage and applying Wet to the target.
    /// </summary>
    public class SwashbucklingStrike_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:SwashbucklingStrike";
        public override string Name => "Swashbuckling Strike";
        public override string Description => "Deal damage and apply Wet.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/SwashbucklingStrike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(15, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to the target and apply Wet (1 stack)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage upgrade handled by dynamic variable
        }
    }
}