using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare X-cost skill that allows the player to imbue and discard cards from the draw pile.
    /// </summary>
    public class Wash_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Wash";
        public override string Name => "Wash";
        public override string Description => "Choose X cards from your draw pile, imbue them and discard them.";
        public override EnergyCost? Cost => EnergyCost.XCost();
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Wash";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: choose X+1 cards from the draw pile, apply Imbued to them and discard them
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version allows selecting one additional card (X+1)
        }
    }
}