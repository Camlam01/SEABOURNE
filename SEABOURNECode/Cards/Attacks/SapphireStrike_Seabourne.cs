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
    /// Common attack that acquires a Sapphire gem and deals damage. Exhausts on play.
    /// </summary>
    public class SapphireStrike_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:SapphireStrike";
        public override string Name => "Sapphire Strike";
        public override string Description => "Acquire a Sapphire and deal damage. Exhaust.";
        public override EnergyCost? Cost => EnergyCost.From(1);
        public override CardType Type => CardType.Attack;
        public override CardRarity Rarity => CardRarity.Common;
        public override CardTarget Target => CardTarget.Enemy;
        public override string PortraitPath => "SEABOURNE/Images/SapphireStrike";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.From(CardTag.Exhaust);
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            DamageVar.ForDamage(8, 4)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: acquire Sapphire gem and deal damage equal to DamageVar to the target
            // await DamageCmd.Attack(state.Card, state.Target, GetVar(DamageVar)).Run();
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Damage upgrades automatically via dynamic variable.
        }
    }
}