using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that grants temporary Slippery stacks and permanently reduces its own Slippery.
    /// </summary>
    public class MucusMask_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:MucusMask";
        public override string Name => "Mucus Mask";
        public override string Description => "Gain Slippery this turn; this card loses Slippery permanently.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/MucusMask";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply Slippery stacks to player (1 base, 2 upgraded) for this turn
            // and remove one permanent Slippery stack from this card for the remainder of the combat
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version applies 2 Slippery instead of 1
        }
    }
}