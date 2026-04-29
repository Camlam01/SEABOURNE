using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SeaShieldCard : SeaborneCard
{
    private int _blockAmount = 12;

    public SeaShieldCard() : base(1, CardType.Skill, CardRarity.Rare, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await BlockCmd.Gain(_blockAmount).FromCard(this).Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        _blockAmount = 15;
    }

    private Task OnReeled()
    {
        return Task.CompletedTask;
    }
}
