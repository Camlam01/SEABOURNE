using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that reels the hooked card and grants block.
    /// </summary>
    public class PullThrough_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:PullThrough";
        public override string Name => "Pull Through";
        public override string Description => "Reel and gain Block.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/PullThrough";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(11, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: reel cards and grant block equal to BlockVar
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variable handles block increase
        }
    }
}