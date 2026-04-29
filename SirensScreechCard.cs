using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SirensScreechCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _tranceAmount = 3;

    public SirensScreechCard() : base(3, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.ApplyTrance(cardPlay.Target!, ModifyGemStacks(_tranceAmount));
    }

    protected override void OnUpgrade()
    {
        _tranceAmount = 4;
    }

    private async Task OnReeled()
    {
        object? player = SeaborneReflectionTools.GetPlayer();
        if (player is not null)
        {
            await SeabornePowerTools.ApplyPowerToPlayer("Seaborne:SirenEcho", ModifyGemStacks(1));
        }
    }
}
