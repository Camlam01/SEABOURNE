using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using SEABOURNE.SEABOURNECode.DynamicVars;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Uncommon skill that acquires either an Emerald or Amber and grants Cast. This card is innate.
    /// </summary>
    public class SunkenTreasure_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:SunkenTreasure";
        public override string Name => "Sunken Treasure";
        public override string Description => "Acquire an Emerald or Amber and gain Cast. Innate.";
        public override string PortraitPath => "SEABOURNE/Images/SunkenTreasure";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Innate];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new CastVar(2).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire either an Emerald or Amber gem and apply Cast equal to CastVar
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // No cost change; Cast remains the same
        }
    }
}