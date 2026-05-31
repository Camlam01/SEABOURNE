using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that imbues a chosen card in hand. Exhausts on play.
    /// </summary>
    public class Sorcery_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Sorcery";
        public override string Name => "Sorcery";
        public override string Description => "Add Imbued to a card in your hand. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Sorcery";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: select a card in hand and apply Imbued 1 to it
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 1 to 0
            EnergyCost.UpgradeBy(-1);
        }
    }
}