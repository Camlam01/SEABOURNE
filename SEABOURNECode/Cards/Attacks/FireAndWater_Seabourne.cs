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
    /// Uncommon attack that deals damage, grants block and acquires either a Ruby or Sapphire. This card is innate.
    /// </summary>
    public class FireAndWater_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:FireAndWater";
        public override string Name => "Fire & Water";
        public override string Description => "Deal damage, gain block and acquire a Ruby or Sapphire. Innate.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/FireAndWater";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Innate);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(5, 0),
            BlockVar.ForBlock(5, 0)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage to the target, grant BlockVar block to the player and acquire either a Ruby or Sapphire gem
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version may increase damage/block or grant both gems; handle in OnPlay
        }
    }
}