using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill granting temporary Strength based on the number of cards reeled this turn. Applies Wet.
    /// </summary>
    public class BarbedHook_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:BarbedHook";
        public override string Name => "Barbed Hook";
        public override string Description => "Gain Strength this turn equal to the number of cards reeled. Wet.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/BarbedHook";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: for each card reeled this turn, grant the player temporary strength and apply Wet to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version may increase Wet stacks; handled in OnPlay
        }
    }
}