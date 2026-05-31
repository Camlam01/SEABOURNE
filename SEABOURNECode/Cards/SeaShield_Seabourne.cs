using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that grants block and applies Wet.
    /// </summary>
    public class SeaShield_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:SeaShield";
        public override string Name => "Sea Shield";
        public override string Description => "Gain block. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/SeaShield";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(12, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: grant BlockVar block to the player and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block increases via dynamic variable
        }
    }
}