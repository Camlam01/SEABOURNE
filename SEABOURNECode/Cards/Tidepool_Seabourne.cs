using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that deals a small amount of damage and grants Waterwall. It applies Weak and Vulnerable
    /// to all enemies and creates a copy of itself in the discard pile. This card has the Wet keyword so
    /// that it is played automatically when reeled. Upgrades increase the numbers slightly.
    /// </summary>
    public class Tidepool_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Tidepool";
        public override string Name => "Tidepool";
        public override string Description => "Deal damage, gain Waterwall, apply Weak and Vulnerable to all enemies and add a copy to your discard pile. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/Tidepool";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 1),
            BlockVar.ForBlock(5, 1)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Deal DamageVar damage to all enemies, gain BlockVar Waterwall stacks, apply 1 Weak and 1 Vulnerable to all enemies,
            // then create a copy of this card in the discard pile. This card should have the Wet keyword so it is automatically played when reeled.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variables handle damage and block upgrades; cost remains unchanged.
        }
    }
}