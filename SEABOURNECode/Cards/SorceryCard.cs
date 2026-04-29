using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SorceryCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public SorceryCard() : base(1, CardType.Skill, CardRarity.Rare, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.ApplyImbued(ModifyGemStacks(1));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        SeaborneCost = 0;
    }
}
