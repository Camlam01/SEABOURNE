using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class RockySeasCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;
    public RockySeasCard() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        object? player = SeaborneReflectionTools.GetPlayer();
        int waterwall = player is null ? 0 : SeaborneReflectionTools.GetPowerStacks(player, WaterwallPower.Id);
        await BlockCmd.Gain(waterwall).FromCard(this).Execute(choiceContext);
        await SeaborneDiscardTools.AddCast(ModifyGemCast(1));
    }

    private async Task OnReeled()
    {
        await SeaborneDiscardTools.AddCast(ModifyGemCast(1));
    }
}
