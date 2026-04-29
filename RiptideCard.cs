using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class RiptideCard : SeaborneCard
{
    private int _blockPerCard = 2;

    public RiptideCard() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();

        object? player = SeaborneReflectionTools.GetPlayer();
        int handSize = (SeaborneReflectionTools.GetMemberValue(player!, "Hand") as System.Collections.ICollection)?.Count ?? 0;

        await BlockCmd.Gain(handSize * _blockPerCard).FromCard(this).Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        _blockPerCard = 3;
    }
}
