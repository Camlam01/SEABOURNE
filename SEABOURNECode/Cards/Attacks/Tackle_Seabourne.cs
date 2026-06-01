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
    /// Common attack that strikes the target multiple times for small damage. Upgraded hits one additional time.
    /// </summary>
    public class Tackle_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Tackle";
        public override string Name => "Tackle";
        public override string Description => "Deal small damage multiple times.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Tackle";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(3, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: hit the target multiple times (2 times base, 3 times upgraded) dealing DamageVar damage each time
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No variable values change; number of hits increases in OnPlay
        }
    }
}