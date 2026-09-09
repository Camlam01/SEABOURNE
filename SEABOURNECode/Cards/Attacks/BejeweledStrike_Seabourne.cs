using System.Threading.Tasks;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.ValueProps;
// Removed invalid Enums namespace. Enumerations are resolved via global imports or the Entities.Cards namespace.
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using BaseLib.Abstracts;
    using SEABOURNE.SEABOURNECode.Cards;
    using MegaCrit.Sts2.Core.Entities.Cards;

namespace SEABOURNE.SEABOURNECode.Cards.Attacks
{
    /// <summary>
    /// Rare attack that deals damage, increases gem slot capacity and acquires a random gem.
    /// </summary>
    public class BejeweledStrike_Seabourne : SeabourneCard(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:BejeweledStrike";
        public override string Name => "Bejeweled Strike";
        public override string Description => "Deal damage, gain a gem slot and acquire a gem.";
        public override string PortraitPath => "SEABOURNE/Images/BejeweledStrike";
        protected override HashSet<CardTag> CanonicalTags => [];
        protected override IEnumerable<DynamicVar> CanonicalVars => [
new DamageVar(10, ValueProp.Move).WithUpgrade(5)
        ];
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: deal DamageVar damage to the target, grant a gem slot and acquire one of Ruby, Sapphire or Emerald
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable
        }
    }
}