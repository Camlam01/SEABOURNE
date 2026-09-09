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

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Common attack that reels, deals damage to all enemies and applies Vulnerable.
    /// </summary>
    public class LineWhip_Seabourne : SeabourneCard(2, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:LineWhip";
        public override string Name => "Line Whip";
        public override string Description => "Reel, deal damage and apply Vulnerable to all enemies.";
        public override string PortraitPath => "SEABOURNE/Images/LineWhip";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 2)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: reel cards, deal DamageVar damage to all enemies and apply Vulnerable (1 base, 2 upgraded)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; vulnerable stacks handled in OnPlay
        }
    }
}