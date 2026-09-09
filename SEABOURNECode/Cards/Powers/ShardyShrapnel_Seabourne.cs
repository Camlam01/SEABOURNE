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

namespace SEABOURNE.SEABOURNECode.Cards.Powers
{
    /// <summary>
    /// Uncommon power that increases the shrapnel damage dealt by cannonballs.
    /// </summary>
    public class ShardyShrapnel_Seabourne : SeabourneCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
    {
        public const string ID = "Seabourne:ShardyShrapnel";
        public override string Name => "Shardy Shrapnel";
        public override string Description => "Increase shrapnel damage.";
        public override string PortraitPath => "SEABOURNE/Images/ShardyShrapnel";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(6, 2)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: apply a power that increases shrapnel damage by DamageVar (6 base, 8 upgraded)
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}