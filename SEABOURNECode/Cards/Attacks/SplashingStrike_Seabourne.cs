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
    /// Common attack that applies Cast and deals splash damage to all enemies, applying Wet.
    /// </summary>
    public class SplashingStrike_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:SplashingStrike";
        public override string Name => "Splashing Strike";
        public override string Description => "Cast 1, deal damage to all enemies and apply Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/SplashingStrike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(1, 0),
            DamageVar.ForDamage(5, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply Cast to player, deal DamageVar damage to all enemies and apply Wet (1 base, 2 upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Wet stacks increase on upgrade; handled in OnPlay
        }
    }
}