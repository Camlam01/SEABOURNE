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
    /// Uncommon skill that grants Cast and creates Spiny Cannonball cards.
    /// </summary>
    public class ReadyForWar_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:ReadyForWar";
        public override string Name => "Ready for War";
        public override string Description => "Cast and create Spiny Cannonballs.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/ReadyForWar";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(3, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply CastVar stacks of Cast and create 1 Spiny Cannonball (2 when upgraded) in the player's hand
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Additional spiny cannonball created when upgraded
        }
    }
}