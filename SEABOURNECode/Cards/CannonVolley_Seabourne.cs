using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon attack that fires the cannon, increasing damage for each consecutive cannonball.
    /// </summary>
    public class CannonVolley_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:CannonVolley";
        public override string Name => "Cannon Volley";
        public override string Description => "Fire the cannon; each consecutive cannonball deals increased damage.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/CannonVolley";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: fire the cannon; implement ramping damage (each cannonball deals 20% more damage than the previous)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change or dynamic variables; behaviour may remain constant
        }
    }
}