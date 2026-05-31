using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that grants a Diamond and modifies Diamonds so that they can apply Wet to any card. When upgraded
    /// the cost is reduced. Actual power application should be handled in OnPlay.
    /// </summary>
    public class FlawlessStone_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:FlawlessStone";
        public override string Name => "Flawless Stone";
        public override string Description => "Gain a Diamond. Diamonds can apply Wet to any card.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/FlawlessStone";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Acquire a Diamond gem and modify Diamonds so they apply Wet to any card when used.
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1 on upgrade
            EnergyCost.UpgradeBy(-1);
        }
    }
}
