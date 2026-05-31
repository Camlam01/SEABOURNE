using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that allows the player to choose any gem at the start of their turn and acquire it. Upgrading
    /// reduces the energy cost, making it free to play.
    /// </summary>
    public class XMarksTheSpot_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:XMarksTheSpot";
        public override string Name => "X Marks the Spot";
        public override string Description => "At the start of your turn choose any Gem and acquire it.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/XMarksTheSpot";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Apply a power that lets the player choose any gem at the start of their turn and acquire it.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}