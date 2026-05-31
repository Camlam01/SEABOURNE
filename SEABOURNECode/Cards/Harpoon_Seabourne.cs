using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that deals damage, grants Cast and reels the hooked card. This card applies Wet
    /// so that when it is reeled it is played immediately. Upgrades increase the damage dealt.
    /// </summary>
    public class Harpoon_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Harpoon";
        public override string Name => "Harpoon";
        public override string Description => "Deal damage, gain Cast and reel. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/Harpoon";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(15, 5),
            CastVar.ForCast(6, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Deal DamageVar damage to the target, gain CastVar stacks of Cast and reel the hooked card.
            // Apply Wet so that when this card is reeled it is played immediately.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // DamageVar upgrade handles increased damage; Cast remains the same.
        }
    }
}