using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that grants Waterwall and reflects deflected damage back at enemies.
    /// </summary>
    public class Torrents_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Torrents";
        public override string Name => "Torrents";
        public override string Description => "Gain Waterwall. When an attack is deflected, return the damage to the enemy.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Torrents";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(6, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that grants BlockVar Waterwall and reflects any deflected damage back at attackers
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Waterwall amount increases via dynamic variable
        }
    }
}