using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that grants energy and applies Wet. Upgraded version costs one less energy.
    /// </summary>
    public class PowerOfTheSea_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:PowerOfTheSea";
        public override string Name => "Power of the Sea";
        public override string Description => "Gain energy. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/PowerOfTheSea";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: gain 2 energy and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 when upgraded
            EnergyCost.UpgradeBy(-1);
        }
    }
}