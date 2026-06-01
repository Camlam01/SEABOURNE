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
    /// Uncommon attack that deals damage to all enemies and discards cards from the draw pile.
    /// </summary>
    public class TideTear_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:TideTear";
        public override string Name => "Tide Tear";
        public override string Description => "Deal damage to all enemies and discard cards from your draw pile.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.AllEnemies;
        public override string PortraitPath => "SEABOURNE/Images/TideTear";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(6, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to all enemies and discard the top 3 cards of the draw pile (4 when upgraded)
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; number of cards discarded increases; implement in OnPlay
        }
    }
}