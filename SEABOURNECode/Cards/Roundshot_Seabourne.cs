using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Uncommon cannonball that loads into the cannon for a powerful damage payload.
    /// </summary>
    public class Roundshot_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Roundshot";
        public override string Name => "Roundshot";
        public override string Description => "Load into the cannon. Deals heavy damage when fired.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Roundshot";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(SeabourneTag.Cannonball);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(30, 10)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // This card loads into the cannon; damage is applied when fired
            await Task.CompletedTask;
        }

        public override bool ShouldMoveToDiscard() => false;

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}