using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that reels and deals damage to a single target.
    /// </summary>
    public class Whiplash_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Whiplash";
        public override string Name => "Whiplash";
        public override string Description => "Reel and deal damage.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Whiplash";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(8, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: reel cards then deal DamageVar damage to the selected enemy
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}