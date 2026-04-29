using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class TidalBarrierCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    private int _waves = 3;

    public TidalBarrierCard() : base(2, CardType.Skill, CardRarity.Uncommon, TargetType.None)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();

        for (int index = 0; index < _waves; index++)
        {
            await SeaborneCardTools.GainWaterwall(ModifyGemStacks(4));
        }
    }

    protected override void OnUpgrade()
    {
        _waves = 4;
    }
}
