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
    /// Uncommon skill that converts Waterwall into block and grants Cast. Applies Wet to this card.
    /// </summary>
    public class RockySeas_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:RockySeas";
        public override string Name => "Rocky Seas";
        public override string Description => "Gain block equal to your Waterwall and Cast. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/RockySeas";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(1, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: gain block equal to current Waterwall stacks, apply CastVar stacks of Cast, and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Cast amount may remain constant; upgrade might improve Wet or other effect
        }
    }
}