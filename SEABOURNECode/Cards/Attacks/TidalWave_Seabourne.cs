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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that deals damage to all enemies based on the number of cards in hand and applies Wet.
    /// </summary>
    public class TidalWave_Seabourne() : SeabourneCard(1, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:TidalWave";
        public override string Name => "Tidal Wave";
        public override string Description => "Deal damage per card in hand and apply Wet.";
        public override string PortraitPath => "SEABOURNE/Images/TidalWave";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(2, ValueProp.Move).WithUpgrade(1)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: deal DamageVar damage times the number of cards in hand to all enemies and apply Wet
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Base damage increased via dynamic variable; wet stacks remain constant
        }
    }
}