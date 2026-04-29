using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class DeterminedCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public DeterminedCard() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.AllEnemies) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.ApplyPowerToAllEnemies("Strength", ModifyGemStacks(3));
        await SeaborneCardTools.GainSlippery(ModifyGemStacks(1));
        await ApplyGemWetIfAny();
    }
}
