using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that grants Cast and deals damage.
    /// </summary>
    public class RodRam_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:RodRam";
        public override string Name => "Rod Ram";
        public override string Description => "Cast and deal damage.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/RodRam";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(2, 0),
            DamageVar.ForDamage(5, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply CastVar amount of Cast then deal DamageVar damage to the target
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases automatically; Cast stays constant
        }
    }
}