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
    /// Rare attack that fires all charged gems at the target for significant damage.
    /// </summary>
    public class GemCannon_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:GemCannon";
        public override string Name => "Gem Cannon";
        public override string Description => "Fire all your gems at the target for damage.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/GemCannon";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(20, 10)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: fire each charged gem at the target, dealing DamageVar damage per gem (30 when upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage per gem increases via dynamic variable
        }
    }
}