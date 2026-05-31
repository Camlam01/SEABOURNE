using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that reels and loads all cannonballs in the player's hand into the cannon. Upgraded version costs one less energy.
    /// </summary>
    public class FullyLoaded_Skill_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:FullyLoaded_Skill";
        public override string Name => "Fully Loaded";
        public override string Description => "Reel and load all cannonballs in your hand.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/FullyLoaded";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: reel cards then load all cannonball cards currently in hand into the cannon
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