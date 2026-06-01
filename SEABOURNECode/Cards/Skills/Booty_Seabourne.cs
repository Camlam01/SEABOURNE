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

namespace SEABOURNE.SEABOURNECode.Cards.Skills
{
    /// <summary>
    /// Rare skill that grants block, increases gem slot capacity and acquires a gem.
    /// </summary>
    public class Booty_Seabourne : SeabourneCard
    {
        public const string ID = "Seabourne:Booty";
        public override string Name => "Booty";
        public override string Description => "Gain block, gain a gem slot and acquire a gem.";
        public override EnergyCost? Cost => EnergyCost.From(3);
        public override CardType Type => CardType.Skill;
        public override CardRarity Rarity => CardRarity.Rare;
        public override CardTarget Target => CardTarget.Self;
        public override string PortraitPath => "SEABOURNE/Images/Booty";
        public override CardAspectSequence? CanonicalTags => CardTagsProvider.Instance.Empty;
        public override CardVarSequence? CanonicalVars => CardVarsProvider.Instance.From(
            BlockVar.ForBlock(15, 5)
        );

        public override async Task OnPlay(CardPlayState state)
        {
            // TODO: grant BlockVar block, grant an additional gem slot and acquire either an Amber or Opal gem
            await Task.CompletedTask;
        }

        public override void OnUpgrade()
        {
            base.OnUpgrade();
            // Block increases via dynamic variable; other effects remain unchanged
        }
    }
}