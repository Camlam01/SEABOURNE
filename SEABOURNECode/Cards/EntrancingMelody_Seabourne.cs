using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that applies Trance multiple times to all enemies.
    /// </summary>
    public class EntrancingMelody_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:EntrancingMelody";
        public override string Name => "Entrancing Melody";
        public override string Description => "Apply Trance repeatedly to all enemies.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/EntrancingMelody";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply 3 Trance to all enemies twice (3 times when upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Number of times increased from 2 to 3
        }
    }
}