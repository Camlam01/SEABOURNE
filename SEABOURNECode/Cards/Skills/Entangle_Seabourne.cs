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

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that applies Cast to the player and Weak to all enemies.
    /// </summary>
    public class Entangle_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Entangle";
        public override string Name => "Entangle";
        public override string Description => "Cast and apply Weak to all enemies.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/Entangle";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(2, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply Cast to player and apply Weak to all enemies (1, upgraded 2)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // When upgraded the Weak applied becomes 2; this should be handled within the OnPlay implementation.
        }
    }
}