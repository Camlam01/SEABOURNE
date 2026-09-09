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
    /// Common skill that acquires a Ruby gem and grants block. Exhausts when played.
    /// </summary>
    public class RubyRuse_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:RubyRuse";
        public override string Name => "Ruby Ruse";
        public override string Description => "Acquire a Ruby and gain Block.";
        public override string PortraitPath => "SEABOURNE/Images/RubyRuse";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(8, 2)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire a Ruby gem and grant block equal to the BlockVar
            // Example: await CreatureCmd.GainBlock(state.Owner, GetVar(BlockVar)).Run();
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // BlockVar upgrade handled via CanonicalVars
        }
    }
}