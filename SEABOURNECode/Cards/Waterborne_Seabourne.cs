using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that gives a card Wet and grants Waterwall. It targets the player and affects a chosen card in hand.
    /// </summary>
    public class Waterborne_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Waterborne";
        public override string Name => "Waterborne";
        public override string Description => "Give a card in your hand Wet and gain Waterwall.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Waterborne";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: select a card in hand, apply Wet to it, and grant 8 Waterwall (12 when upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Waterwall amount increases when upgraded
        }
    }
}