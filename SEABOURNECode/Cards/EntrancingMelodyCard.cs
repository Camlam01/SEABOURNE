using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EntrancingMelodyCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _repeats = 2;

    public EntrancingMelodyCard() : base(2, CardType.Skill, CardRarity.Rare, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();

        for (int index = 0; index < _repeats; index++)
        {
            await SeaborneCardTools.ApplyTrance(cardPlay.Target!, ModifyGemStacks(3));
        }
    }

    protected override void OnUpgrade()
    {
        _repeats = 3;
    }
}
