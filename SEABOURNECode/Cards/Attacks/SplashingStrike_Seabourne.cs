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
    public class SplashingStrike_Seabourne : SeabourneCard(1, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:SplashingStrike";
        public override string Name => "Splashing Strike";
        public override string Description => "Cast 1, deal damage to all enemies and apply Wet.";
        public override string PortraitPath => "SEABOURNE/Images/SplashingStrike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(1, 0),
            DamageVar.ForDamage(5, 0)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply Cast to player, deal DamageVar damage to all enemies and apply Wet (1 base, 2 upgraded)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Wet stacks increase on upgrade; handled in OnPlay
        }
    }
}