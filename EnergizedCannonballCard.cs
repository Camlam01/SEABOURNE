using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class EnergizedCannonballCard : SeaborneCard
{
    public override bool HasAttackDamage => true;

    private decimal _damage = 15m;

    public EnergizedCannonballCard() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.LoadCannonball();
        await DamageCmd.Attack(ModifyGemDamage(_damage)).FromCard(this).Targeting(cardPlay.Target).Execute(choiceContext);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _damage = 20m;
    }
}
