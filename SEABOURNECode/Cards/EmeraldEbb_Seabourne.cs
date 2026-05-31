using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that acquires an Emerald gem and grants Waterwall. Exhausts on play.
    /// </summary>
    public class EmeraldEbb_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:EmeraldEbb";
        public override string Name => "Emerald Ebb";
        public override string Description => "Acquire an Emerald and gain Waterwall. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/EmeraldEbb";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire Emerald gem and apply Waterwall stacks (base 7, upgrade 9)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; waterwall amount should increase when upgraded.
        }
    }
}