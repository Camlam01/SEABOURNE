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

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that reels cards and enchants the first few reeled cards without spending gem charges.
    /// </summary>
    public class PerfectCatch_Seabourne : SeabourneCard(2, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:PerfectCatch";
        public override string Name => "Perfect Catch";
        public override string Description => "Reel and enchant reeled cards without gem cost.";
        public override string PortraitPath => "SEABOURNE/Images/PerfectCatch";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.Empty;

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: reel cards and enchant the first 2 reeled cards without using gem charges (3 when upgraded)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Number of enchanted cards increases from 2 to 3
        }
    }
}