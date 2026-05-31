using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Starter attack which simply fires the Seabourne's cannon. When upgraded the cost is reduced by one.
    /// </summary>
    public class FireCannon_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:FireCannon";
        public override string Name => "Fire Cannon";
        public override string Description => "Fire the cannon.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Starter;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/FireCannon";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: implement firing the cannon; this should trigger the cannon's damage effect.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}