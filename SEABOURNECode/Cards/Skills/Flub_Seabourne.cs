using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.DynamicVars;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Common skill that grants Cast and block. Cast causes the hooked card to move deeper into the discard pile.
    /// </summary>
    public class Flub_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
    {
        public const string ID = "Seabourne:Flub";
        public override string Name => "Flub";
        public override string Description => "Gain Cast and Block.";
        public override string PortraitPath => "SEABOURNE/Images/Flub";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new CastVar(2).WithUpgrade(1),
            new BlockVar(7, ValueProp.Move).WithUpgrade(1)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply Cast and gain block based on dynamic variables
            // await PowerCmd.Apply<CastPower>(state.Owner, GetVar(CastVar)).Run();
            // await CreatureCmd.GainBlock(state.Owner, GetVar(BlockVar)).Run();
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variables will upgrade automatically.
        }
    }
}