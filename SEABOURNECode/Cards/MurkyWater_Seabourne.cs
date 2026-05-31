using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that grants a large amount of Waterwall.
    /// </summary>
    public class MurkyWater_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:MurkyWater";
        public override string Name => "Murky Water";
        public override string Description => "Gain a large amount of Waterwall.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/MurkyWater";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(25, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: grant Waterwall equal to BlockVar to the player
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Waterwall amount increases via dynamic variable
        }
    }
}