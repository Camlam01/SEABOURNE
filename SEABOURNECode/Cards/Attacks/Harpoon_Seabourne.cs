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
    /// Rare attack that deals damage, grants Cast and reels the hooked card. This card applies Wet
    /// so that when it is reeled it is played immediately. Upgrades increase the damage dealt.
    /// </summary>
    public class Harpoon_Seabourne : SeabourneCard(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
    {
        public const string ID = "Seabourne:Harpoon";
        public override string Name => "Harpoon";
        public override string Description => "Deal damage, gain Cast and reel. Wet.";
        public override string PortraitPath => "SEABOURNE/Images/Harpoon";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(15, 5),
            CastVar.ForCast(6, 0)
        );

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // TODO: Deal DamageVar damage to the target, gain CastVar stacks of Cast and reel the hooked card.
            // Apply Wet so that when this card is reeled it is played immediately.
            await Task.CompletedTask;
        }

        protected override void OnUpgrade()
        {
            base.OnUpgrade();
            // DamageVar upgrade handles increased damage; Cast remains the same.
        }
    }
}