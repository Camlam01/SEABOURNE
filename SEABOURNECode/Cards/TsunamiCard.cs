using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class TsunamiCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;

    private int _amount = 20;

    public TsunamiCard() : base(3, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await DamageCmd.Attack(ModifyGemDamage(_amount)).FromCard(this).Targeting(cardPlay.Target!).Execute(choiceContext);
        await SeaborneCardTools.GainWaterwall(ModifyGemStacks(_amount));
    }

    protected override void OnUpgrade()
    {
        _amount = 25;
    }
}
