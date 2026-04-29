using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class TrawlCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;
    public TrawlCard() : base(-1, CardType.Skill, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        int x = Math.Max(0, SeaborneCardTools.GetEnergySpent(cardPlay));
        await SeaborneDiscardTools.AddCast(ModifyGemCast(x));
        await SeaborneDiscardTools.Reel(ModifyGemReel(2 * x));
    }
}
