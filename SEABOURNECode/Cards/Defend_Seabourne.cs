using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Basic defensive card: grants block to the player.
    /// </summary>
    public class Defend_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Defend";
        public override string Name => "Defend";
        public override string Description => "Gain {Block} Block.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Basic;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Defend";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Defend);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(5, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // Block application handled by engine commands.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variable handles block increase.
        }
    }
}