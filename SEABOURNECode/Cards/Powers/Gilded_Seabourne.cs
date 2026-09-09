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

namespace SEABOURNE.SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that rewards the player with energy when their hand is full.
    /// </summary>
    public class Gilded_Seabourne : SeabourneCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:Gilded";
        public override string Name => "Gilded";
        public override string Description => "Gain energy when your hand reaches its maximum size.";
        public override string PortraitPath => "SEABOURNE/Images/Gilded";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            EnergyVar.ForEnergy(2, 1)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply a power that gives the player EnergyVar energy the first time they have 10 cards in hand each turn
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Energy reward increases via dynamic variable
        }
    }
}