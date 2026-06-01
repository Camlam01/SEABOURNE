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
    /// Uncommon skill that acquires either an Emerald or Amber and grants Cast. This card is innate.
    /// </summary>
    public class SunkenTreasure_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:SunkenTreasure";
        public override string Name => "Sunken Treasure";
        public override string Description => "Acquire an Emerald or Amber and gain Cast. Innate.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/SunkenTreasure";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Innate);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(2, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire either an Emerald or Amber gem and apply Cast equal to CastVar
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; Cast remains the same
        }
    }
}