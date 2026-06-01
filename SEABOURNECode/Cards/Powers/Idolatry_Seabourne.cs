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
    /// Uncommon power that deals damage to all enemies whenever the player plays a modified card.
    /// </summary>
    public class Idolatry_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Idolatry";
        public override string Name => "Idolatry";
        public override string Description => "Whenever you play a card with a modifier, deal damage to all enemies.";
        public override EnergyCost? Cost => EnergyCost.From(2);
        public override CardType Type => CardType.Power;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Idolatry";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(4, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: apply a power that deals DamageVar damage to all enemies whenever the player plays a card with a modifier
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}