using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Starter skill that grants Cast and immediately reels the hooked card into the player's hand.
    /// </summary>
    public class Fish_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:Fish";
        public override string Name => "Fish";
        public override string Description => "Cast 1. Reel.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Starter;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Fish";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply one stack of Cast and then reel cards according to cast count
            // e.g. await PowerCmd.Apply<CastPower>(state.Owner, 1).Run();
            // await ReelUtils.ReelAsync(state.Owner);
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; values remain the same.
        }
    }
}