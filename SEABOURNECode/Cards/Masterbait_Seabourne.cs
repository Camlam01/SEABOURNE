using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that increases the amount of Cast gained each time the player casts.
    /// </summary>
    public class Masterbait_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Masterbait";
        public override string Name => "Masterbait";
        public override string Description => "Whenever you cast, gain an additional Cast.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Masterbait";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that causes the player to gain an additional Cast whenever they gain Cast
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