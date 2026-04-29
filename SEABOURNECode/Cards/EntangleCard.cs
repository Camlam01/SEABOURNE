using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EntangleCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;
    public EntangleCard() : base(1, CardType.Skill, CardRarity.Common, TargetType.AllEnemies) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.AddCast(ModifyGemCast(2));
        foreach (var enemy in SeaborneCardTools.GetEnemyCreatures())
        {
            await SeabornePowerTools.ApplyPowerToTarget(enemy, "Weak", IsSeaborneUpgraded ? 2 : 1);
        }
    }
}
