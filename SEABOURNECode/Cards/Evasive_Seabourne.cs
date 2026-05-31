using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that grants Slippery stacks but prevents the player from gaining block. Upgrades increase
    /// the number of Slippery stacks granted.
    /// </summary>
    public class Evasive_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Evasive";
        public override string Name => "Evasive";
        public override string Description => "Gain Slippery. Cannot gain block.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Evasive";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Apply a power that gives the player Slippery (5 or 7 when upgraded) and prevents them from gaining block.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: increase the amount of Slippery granted from 5 to 7. No cost change.
        }
    }
}
