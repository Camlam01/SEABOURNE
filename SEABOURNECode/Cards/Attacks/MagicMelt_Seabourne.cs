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
    /// Rare attack that deals damage to all enemies, grants block and has multiple Imbued stacks.
    /// </summary>
    public class MagicMelt_Seabourne : SeabourneCard(1, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
    {
        public const string ID = "Seabourne:MagicMelt";
        public override string Name => "Magic Melt";
        public override string Description => "Deal damage to all and gain block. Imbued.";
        public override string PortraitPath => "SEABOURNE/Images/MagicMelt";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(5, ValueProp.Move).WithUpgrade(0),
            new BlockVar(5, ValueProp.Move).WithUpgrade(0)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: deal DamageVar damage to all enemies, grant BlockVar block to the player and apply 3 Imbued (4 when upgraded) to this card
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Imbued stacks increase; damage and block stay constant
        }
    }
}