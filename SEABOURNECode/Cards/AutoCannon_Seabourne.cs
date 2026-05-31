using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that causes the cannon to fire at the start of the player's turn. Applies Wet to the card.
    /// </summary>
    public class AutoCannon_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:AutoCannon";
        public override string Name => "Auto Cannon";
        public override string Description => "Fire the cannon at the start of your turn. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/AutoCannon";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that automatically fires the cannon at the start of each turn and mark this card as Wet
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No change when upgraded; Wet property persists
        }
    }
}