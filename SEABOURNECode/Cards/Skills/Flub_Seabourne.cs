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
    /// Common skill that grants Cast and block. Cast causes the hooked card to move deeper into the discard pile.
    /// </summary>
    public class Flub_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Flub";
        public override string Name => "Flub";
        public override string Description => "Gain Cast and Block.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Flub";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(2, 1),
            BlockVar.ForBlock(7, 1)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply Cast and gain block based on dynamic variables
            // await PowerCmd.Apply<CastPower>(state.Owner, GetVar(CastVar)).Run();
            // await CreatureCmd.GainBlock(state.Owner, GetVar(BlockVar)).Run();
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Dynamic variables will upgrade automatically.
        }
    }
}