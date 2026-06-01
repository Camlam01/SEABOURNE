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
    /// A basic defensive card for Seabourne. Grants block to the player.
    /// </summary>
    public class Defend_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Defend";
        public override string Name => "Defend";
        public override string Description => "Gain {Block} Block.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Basic;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Defend";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Defend);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(5, 3)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // Grant block to the player
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block increase handled by dynamic variable
        }
    }
}
