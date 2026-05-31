using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that grants random gems. Applies Wet. Upgraded version increases the number of gems.
    /// </summary>
    public class LuckOfTheSea_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:LuckOfTheSea";
        public override string Name => "Luck of the Sea";
        public override string Description => "Gain a random treasure. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/LuckOfTheSea";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: gain 1 random gem (2 when upgraded) and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Number of treasures gained increases when upgraded
        }
    }
}