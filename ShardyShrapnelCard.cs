using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class ShardyShrapnelCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _shrapnelDamage = 6;

    public ShardyShrapnelCard() : base(1, CardType.Power, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToPlayer(ShardyShrapnelPower.Id, ModifyGemStacks(_shrapnelDamage));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _shrapnelDamage = 8;
    }
}
