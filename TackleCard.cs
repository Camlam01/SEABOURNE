using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class TackleCard : SeaborneCard
{
    public override bool HasAttackDamage => true;

    protected override IEnumerable<DynamicVar> CanonicalVars => DamageVar(3m);

    private int _hits = 2;

    public TackleCard() : base(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();

        for (int i = 0; i < _hits; i++)
        {
            await DamageCmd.Attack(ModifyGemDamage(DynamicVars.Damage.BaseValue))
                .FromCard(this)
                .Targeting(cardPlay.Target)
                .Execute(choiceContext);
        }
    }

    protected override void OnUpgrade()
    {
        _hits = 3;
    }
}
