using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack dealing heavy damage and granting multiple Imbued stacks.
    /// </summary>
    public class EnchantedCutlass_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:EnchantedCutlass";
        public override string Name => "Enchanted Cutlass";
        public override string Description => "Deal heavy damage and gain Imbued.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/EnchantedCutlass";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(25, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to the target and apply 2 Imbued (3 when upgraded) to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Increase imbued stacks on upgrade; damage remains constant
        }
    }
}