using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that applies Vulnerable and Weak to all enemies and has the Imbued modifier.
    /// </summary>
    public class AncientCurse_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:AncientCurse";
        public override string Name => "Ancient Curse";
        public override string Description => "Apply Vulnerable and Weak to all enemies. Imbued.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/AncientCurse";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply 1 Vulnerable and 1 Weak to all enemies (2 of each when upgraded) and apply Imbued stacks to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Imbued stacks increase from 1 to 2 when upgraded
        }
    }
}