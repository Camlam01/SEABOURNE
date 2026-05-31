using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common cannonball attack card. This card has the Load keyword, meaning it loads into the cannon instead of resolving
    /// immediately. When fired, it deals damage based on the dynamic variable.
    /// </summary>
    public class Cannonball_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Cannonball";
        public override string Name => "Cannonball";
        public override string Description => "Load into the cannon. Deals damage when fired.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Cannonball";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(SeabourneTag.Cannonball);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(15, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // Cannonballs do not resolve on play; they instead load into the cannon. The cannon manager handles damage when fired.
            await Task.CompletedTask;
        }

        public override bool ShouldMoveToDiscard() => false;

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; cost remains the same.
        }
    }
}