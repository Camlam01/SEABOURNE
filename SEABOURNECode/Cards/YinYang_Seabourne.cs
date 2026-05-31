using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon attack that deals damage and applies Weak to all enemies while acquiring a Diamond or Opal. This card is innate.
    /// </summary>
    public class YinYang_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:YinYang";
        public override string Name => "Yin & Yang";
        public override string Description => "Deal damage and apply Weak to all enemies. Acquire Diamond or Opal. Innate.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/YinYang";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Innate);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(8, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to all enemies, apply 1 Weak to each and acquire either a Diamond or an Opal gem
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // When upgraded, this card may apply additional Weak or allow both gems; implement in OnPlay
        }
    }
}