using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon attack dealing significant damage and granting Waterwall to the player.
    /// </summary>
    public class Tsunami_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Tsunami";
        public override string Name => "Tsunami";
        public override string Description => "Deal heavy damage and gain Waterwall.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Tsunami";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(20, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to the enemy and grant the player Waterwall equal to DamageVar (20 base, 25 upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage (and thus Waterwall) increases via dynamic variable
        }
    }
}