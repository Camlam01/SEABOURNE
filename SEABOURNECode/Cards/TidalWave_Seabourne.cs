using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that deals damage to all enemies based on the number of cards in hand and applies Wet.
    /// </summary>
    public class TidalWave_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:TidalWave";
        public override string Name => "Tidal Wave";
        public override string Description => "Deal damage per card in hand and apply Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/TidalWave";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(2, 1)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage times the number of cards in hand to all enemies and apply Wet
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Base damage increased via dynamic variable; wet stacks remain constant
        }
    }
}