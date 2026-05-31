using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that deals damage to all enemies, grants block and has multiple Imbued stacks.
    /// </summary>
    public class MagicMelt_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:MagicMelt";
        public override string Name => "Magic Melt";
        public override string Description => "Deal damage to all and gain block. Imbued.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/MagicMelt";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 0),
            BlockVar.ForBlock(5, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to all enemies, grant BlockVar block to the player and apply 3 Imbued (4 when upgraded) to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Imbued stacks increase; damage and block stay constant
        }
    }
}