using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that applies Trance to an enemy at the cost of giving them Strength.
    /// </summary>
    public class Empower_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Empower";
        public override string Name => "Empower";
        public override string Description => "Apply Trance but give the enemy Strength.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Empower";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply 5 (6 when upgraded) Trance to the target and give it 3 Strength
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Trance amount increases on upgrade
        }
    }
}