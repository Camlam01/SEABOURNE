using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that removes all gems and grants gold for each gem removed. Upgrades increase the
    /// amount of gold gained. This represents selling your treasures for money.
    /// </summary>
    public class Bartering_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Bartering";
        public override string Name => "Bartering";
        public override string Description => "Remove all gems, gain 15 gold for each gem removed.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Bartering";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Remove all gems from the player and grant 15 gold per gem removed (25 gold when upgraded).
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: increase gold gained per gem from 15 to 25. No cost change.
        }
    }
}
