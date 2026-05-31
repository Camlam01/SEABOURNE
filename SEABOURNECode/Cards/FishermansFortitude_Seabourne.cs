using System.Threading.Tasks;

namespace SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that grants block every time the player gains Cast.
    /// </summary>
    public class FishermansFortitude_Seabourne : CustomCardModel
    {
        public const string ID = "Seabourne:FishermansFortitude";
        public override string Name => "Fisherman's Fortitude";
        public override string Description => "Gain block when you cast.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/FishermansFortitude";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(2, 1)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that grants BlockVar block whenever the player gains Cast
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block amount increases via dynamic variable
        }
    }
}