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
    /// Uncommon attack that deals damage, applies Cast and has the Imbued modifier.
    /// </summary>
    public class RodWhip_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:RodWhip";
        public override string Name => "Rod Whip";
        public override string Description => "Deal damage, gain Cast and apply Imbued.";
        public override EnergyCost? Cost => EnergyCost.From(0);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Uncommon;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/RodWhip";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            CastVar.ForCast(1, 0),
            DamageVar.ForDamage(5, 2)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: deal DamageVar damage, apply CastVar stacks of Cast to the player and apply 1 Imbued to this card
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage increases via dynamic variable; imbued stacks may increase when upgraded
        }
    }
}