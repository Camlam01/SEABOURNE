using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class AncientCurseCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public AncientCurseCard() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.AllEnemies) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        int stacks = IsSeaborneUpgraded ? 2 : 1;
        foreach (var enemy in SeaborneCardTools.GetEnemyCreatures())
        {
            await SeaborneCardTools.ApplyVulnerable(enemy, ModifyGemStacks(stacks));
            await SeaborneCardTools.ApplyWeak(enemy, ModifyGemStacks(stacks));
        }
    }
}
