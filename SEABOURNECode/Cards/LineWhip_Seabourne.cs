using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that reels, deals damage to all enemies and applies Vulnerable.
    /// </summary>
    public class LineWhip_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:LineWhip";
        public override string Name => "Line Whip";
        public override string Description => "Reel, deal damage and apply Vulnerable to all enemies.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/LineWhip";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: reel cards, deal DamageVar damage to all enemies and apply Vulnerable (1 base, 2 upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; vulnerable stacks handled in OnPlay
        }
    }
}