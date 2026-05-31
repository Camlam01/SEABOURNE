using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Rare power that increases the number of stacks applied when you apply buffs or debuffs. Upgraded
    /// version increases the bonus percentage.
    /// </summary>
    public class Jinx_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Jinx";
        public override string Name => "Jinx";
        public override string Description => "When you apply buffs or debuffs, apply 50% more stacks.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Jinx";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: Apply a power that multiplies the stacks of buffs or debuffs you apply by 1.5 (or 1.75 when upgraded).
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgrade effect: increase bonus from 50% to 75%. No cost change.
        }
    }
}
