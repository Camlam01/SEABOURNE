using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class MagicMeltCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;

    private int _imbuedAmount = 3;

    public MagicMeltCard() : base(1, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await DamageCmd.Attack(ModifyGemDamage(5m)).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
        await BlockCmd.Gain(5m).FromCard(this).Execute(choiceContext);
        await SeaborneCardTools.ApplyImbued(ModifyGemStacks(_imbuedAmount));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _imbuedAmount = 4;
    }
}
