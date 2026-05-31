using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that acquires a Diamond gem and grants Cast stacks. Exhausts on play.
    /// </summary>
    public class DeepDiamond_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:DeepDiamond";
        public override string Name => "Deep Diamond";
        public override string Description => "Acquire a Diamond and gain Cast. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/DeepDiamond";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(3, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire Diamond gem and grant Cast equal to dynamic variable
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Reduce cost from 2 to 1
            EnergyCost.UpgradeBy(-1);
        }
    }
}