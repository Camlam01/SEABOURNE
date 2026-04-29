using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class IdolatryCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _damageAmount = 4;

    public IdolatryCard() : base(2, CardType.Power, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeabornePowerTools.ApplyPowerToPlayer(IdolatryPower.Id, ModifyGemStacks(_damageAmount));
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        _damageAmount = 6;
    }
}
