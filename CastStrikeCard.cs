using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class CastStrikeCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;

    private int _damagePerEnergy = 6;

    public CastStrikeCard() : base(1, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();

        object? player = SeaborneReflectionTools.GetPlayer();
        int cast = player is null ? 0 : SeaborneReflectionTools.GetPowerStacks(player, CastPower.Id);
        int damage = Math.Max(0, cast) * _damagePerEnergy;

        await SeaborneDiscardTools.AddCast(ModifyGemCast(3));
        await DamageCmd.Attack(ModifyGemDamage(damage))
            .FromCard(this)
            .Targeting(cardPlay.Target)
            .Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        _damagePerEnergy = 8;
    }
}
