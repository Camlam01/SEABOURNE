using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class LiquidMindCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public LiquidMindCard() : base(3, CardType.Skill, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.GainSlippery(ModifyGemStacks(2));
        SeaborneCost = Math.Max(0, SeaborneCost - 1);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        SeaborneCost = 2;
    }
}
