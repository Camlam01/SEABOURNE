using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class SunkenTreasureCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;
    public override bool HasCastOrReel => true;

    private string _gemPowerId = EmeraldGemPower.Id;

    public SunkenTreasureCard() : base(1, CardType.Skill, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AcquireGem(_gemPowerId);
        await SeaborneDiscardTools.AddCast(ModifyGemCast(2));
    }

    protected override void OnUpgrade()
    {
        _gemPowerId = AmberGemPower.Id;
    }
}
