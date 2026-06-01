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
    /// Uncommon skill that grants Slippery and reduces its own cost on subsequent plays.
    /// </summary>
    public class LiquidMind_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:LiquidMind";
        public override string Name => "Liquid Mind";
        public override string Description => "Gain Slippery and reduce this card's cost.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/LiquidMind";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: grant 2 Slippery and reduce this card's cost by 1 (down to a minimum of 0)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce base cost from 3 to 2
            EnergyCost.UpgradeBy(-1);
        }
    }
}