using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Starter
{
    /// <summary>
    /// Starter skill that grants Cast and immediately reels the hooked card into the player's hand.
    /// </summary>
    public class Fish_Seabourne : SeabourneCard
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