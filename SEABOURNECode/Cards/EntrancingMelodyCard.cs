using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EntrancingMelodyCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public EntrancingMelodyCard() : base(2, CardType.Skill, CardRarity.Rare, TargetType.AnyEnemy) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        int repeats = IsSeaborneUpgraded ? 3 : 2;

        for (int index = 0; index < repeats; index++)
        {
            await SeaborneCardTools.ApplyTrance(cardPlay.Target!, ModifyGemStacks(3));
        }
    }
}
