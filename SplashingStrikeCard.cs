using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SplashingStrikeCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;

    protected override IEnumerable<DynamicVar> CanonicalVars => DamageVar(5m);

    private int _reeledCastAmount = 1;

    public SplashingStrikeCard() : base(1, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneDiscardTools.AddCast(ModifyGemCast(1));
        await DamageCmd.Attack(ModifyGemDamage(DynamicVars.Damage.BaseValue))
            .FromCard(this)
            .TargetingAllOpponents(CombatState)
            .Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        _reeledCastAmount = 2;
    }

    private async Task OnReeled()
    {
        await SeaborneDiscardTools.AddCast(ModifyGemCast(_reeledCastAmount));
    }
}
