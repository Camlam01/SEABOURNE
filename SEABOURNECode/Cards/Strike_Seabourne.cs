using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Basic attack card: deals damage to one enemy.
    /// </summary>
    public class Strike_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Strike";
        public override string Name => "Strike";
        public override string Description => "Deal {Damage} damage.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Basic;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Strike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Strike);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(6, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // Damage application handled by engine commands.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variable handles damage increase.
        }
    }
}