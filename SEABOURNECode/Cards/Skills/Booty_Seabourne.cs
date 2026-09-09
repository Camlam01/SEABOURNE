using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that grants block, increases gem slot capacity and acquires a gem.
    /// </summary>
    public class Booty_Seabourne : SeabourneCard(3, CardType.Skill, CardRarity.Rare, TargetType.Self)
    {
        public const string ID = "Seabourne:Booty";
        public override string Name => "Booty";
        public override string Description => "Gain block, gain a gem slot and acquire a gem.";
        public override string PortraitPath => "SEABOURNE/Images/Booty";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new BlockVar(15, ValueProp.Move).WithUpgrade(5)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: grant BlockVar block, grant an additional gem slot and acquire either an Amber or Opal gem
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block increases via dynamic variable; other effects remain unchanged
        }
    }
}