using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class ReadyForWarCard : SeaborneCard
{
    public override bool HasCastOrReel => true;
    public ReadyForWarCard() : base(0, CardType.Skill, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.AddCast(ModifyGemCast(3));
        await SeaborneCardTools.AddCannonballsToHand(IsSeaborneUpgraded ? 2 : 1);
        await ApplyGemWetIfAny();
    }
}
