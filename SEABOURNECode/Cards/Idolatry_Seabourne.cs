using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that deals damage to all enemies whenever the player plays a modified card.
    /// </summary>
    public class Idolatry_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Idolatry";
        public override string Name => "Idolatry";
        public override string Description => "Whenever you play a card with a modifier, deal damage to all enemies.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Idolatry";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(4, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that deals DamageVar damage to all enemies whenever the player plays a card with a modifier
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}