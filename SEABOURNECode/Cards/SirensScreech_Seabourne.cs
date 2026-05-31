using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that applies Trance to an enemy and applies Wet to the card. Upgraded version increases Trance amount.
    /// </summary>
    public class SirensScreech_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:SirensScreech";
        public override string Name => "Siren's Screech";
        public override string Description => "Apply Trance to an enemy. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/SirensScreech";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply Trance (3 base, 4 upgraded) to the targeted enemy and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Trance amount increases when upgraded
        }
    }
}