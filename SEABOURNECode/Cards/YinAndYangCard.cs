using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class YinAndYangCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;

    private string _gemPowerId = DiamondGemPower.Id;

    public YinAndYangCard() : base(2, CardType.Attack, CardRarity.Uncommon, TargetType.AllEnemies)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AcquireGem(_gemPowerId);

        foreach (var enemy in SeaborneCardTools.GetEnemyCreatures())
        {
            await DamageCmd.Attack(ModifyGemDamage(8m)).FromCard(this).Targeting(enemy).Execute(choiceContext);
            await SeaborneCardTools.ApplyWeak(enemy, ModifyGemStacks(1));
        }

        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _gemPowerId = OpalGemPower.Id;
    }
}
