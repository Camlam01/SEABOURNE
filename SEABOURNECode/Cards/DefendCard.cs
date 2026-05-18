using System.Collections.Generic;
using System.Threading.Tasks;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// A basic block card for the Seabourne character.  Grants block
    /// equal to its block variable to the player.  Upgrades increase
    /// the block by 3.
    /// </summary>
    public sealed class DefendCard : SeabourneCard
    {
        public DefendCard() : base(1, CardType.Skill, CardRarity.Basic, TargetType.Self)
        {
        }

        protected override IEnumerable<DynamicVar> CanonicalVars => new DynamicVar[] { new BlockVar(5m, ValueProp.Move) };

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        {
            // Grant block to the card owner using the core command
            await CreatureCmd.GainBlock(Owner.Creature, PrimaryBlock, play);
        }

        protected override void OnUpgrade()
        {
            // Increase block by 3 when upgraded
            PrimaryBlock.UpgradeValueBy(3m);
        }
    }
}