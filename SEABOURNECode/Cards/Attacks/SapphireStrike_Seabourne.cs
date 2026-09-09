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
    /// Common attack that acquires a Sapphire gem and deals damage. Exhausts on play.
    /// </summary>
    public class SapphireStrike_Seabourne : SeabourneCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:SapphireStrike";
        public override string Name => "Sapphire Strike";
        public override string Description => "Acquire a Sapphire and deal damage. Exhaust.";
        public override string PortraitPath => "SEABOURNE/Images/SapphireStrike";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(8, ValueProp.Move).WithUpgrade(4)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: acquire Sapphire gem and deal damage equal to DamageVar to the target
            // await DamageCmd.Attack(state.Card, state.Target, GetVar(DamageVar)).Run();
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage upgrades automatically via dynamic variable.
        }
    }
}