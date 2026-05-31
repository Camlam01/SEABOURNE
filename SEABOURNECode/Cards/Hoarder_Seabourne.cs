using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that increases the player's treasure slots and grants block.
    /// </summary>
    public class Hoarder_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Hoarder";
        public override string Name => "Hoarder";
        public override string Description => "Gain a treasure slot and block.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Hoarder";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(7, 1)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: increase treasure slot count by one and grant block equal to BlockVar
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block increases via dynamic variable
        }
    }
}