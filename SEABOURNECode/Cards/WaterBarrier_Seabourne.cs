using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that converts Cast into Waterwall and then reels cards. Upgraded version costs less energy.
    /// </summary>
    public class WaterBarrier_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:WaterBarrier";
        public override string Name => "Water Barrier";
        public override string Description => "Gain Waterwall equal to your Cast and reel.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/WaterBarrier";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: gain Waterwall equal to the player's Cast stacks then reel cards
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1
            EnergyCost.UpgradeBy(-1);
        }
    }
}