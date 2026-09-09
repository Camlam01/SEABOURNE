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
    /// Uncommon skill that grants block based on the number of cards in hand.
    /// </summary>
    public class Riptide_Seabourne : SeabourneCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:Riptide";
        public override string Name => "Riptide";
        public override string Description => "Gain block per card in hand.";
        public override string PortraitPath => "SEABOURNE/Images/Riptide";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new BlockVar(2, ValueProp.Move).WithUpgrade(1)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: gain BlockVar block for each card in hand (2 per card, 3 when upgraded)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block per card increases via dynamic variable
        }
    }
}