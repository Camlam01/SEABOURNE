using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill with X-cost that grants Cast based on the energy spent and then reels cards.
    /// </summary>
    public class Trawl_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Trawl";
        public override string Name => "Trawl";
        public override string Description => "Spend X energy to gain Cast and reel.";
        public override EnergyCost? Cost => EnergyCost.XCost();
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Trawl";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: gain 2 Cast per energy spent (2X) and then reel cards
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded effect may include reel or additional cast; implemented in OnPlay
        }
    }
}