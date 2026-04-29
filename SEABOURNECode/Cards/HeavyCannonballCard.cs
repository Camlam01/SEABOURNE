using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class HeavyCannonballCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;

    private decimal _damage = 20m;

    public HeavyCannonballCard() : base(2, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.LoadCannonball();
        await DamageCmd.Attack(ModifyGemDamage(_damage)).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
        await SeabornePowerTools.ApplyPowerToTarget(cardPlay.Target, "Stun", ModifyGemStacks(1));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _damage = 30m;
    }
}
