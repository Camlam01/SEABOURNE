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
    /// Uncommon attack that deals damage, grants block and acquires either a Ruby or Sapphire. This card is innate.
    /// </summary>
    public class FireAndWater_Seabourne() : SeabourneCard(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:FireAndWater";
        public override string Name => "Fire & Water";
        public override string Description => "Deal damage, gain block and acquire a Ruby or Sapphire. Innate.";
        public override string PortraitPath => "SEABOURNE/Images/FireAndWater";
        protected override HashSet<CardTag> CanonicalTags => [];
        public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Innate];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(5, ValueProp.Move).WithUpgrade(0),
            new BlockVar(5, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: deal DamageVar damage to the target, grant BlockVar block to the player and acquire either a Ruby or Sapphire gem
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Upgraded version may increase damage/block or grant both gems; handle in OnPlay
        }
    }
}