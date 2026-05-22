using System.Threading.Tasks;
// Note: Avoid importing Multiplayer namespace here to prevent ambiguous overloads of
// PowerCmd.Apply that require a PlayerChoiceContext.  We only need base command functionality.
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.ValueProps;
using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Commands;

namespace SEABOURNE.SEABOURNECode.Powers
{
    public sealed class OpalGemPower : BaseGemPower
    {
        public override string? CustomPackedIconPath =>
            "res://mods/SEABOURNE/images/powers/OpalGemPower.png";

        public override string? CustomBigIconPath =>
            "res://mods/SEABOURNE/images/powers/OpalGemPower.png";

        protected override async Task OnCardPlayed(MegaCrit.Sts2.Core.GameActions.Multiplayer.PlayerChoiceContext context, CardPlay cardPlay)
        {
            this.Flash();
            await MegaCrit.Sts2.Core.Commands.PowerCmd.Apply<CastPower>(
                new[] { base.Owner },
                1m,
                base.Owner,
                cardPlay.Card,
                false);
            MarkUsed();
        }
    }
}