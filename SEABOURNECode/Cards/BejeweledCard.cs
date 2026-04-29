using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class BejeweledCard : SeaborneCard
{
    public override bool HasBuffOrDebuffStacks => true;

    public BejeweledCard() : base(1, CardType.Skill, CardRarity.Rare, TargetType.None) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.AcquireGem(RubyGemPower.Id);
        await SeaborneCardTools.AcquireGem(SapphireGemPower.Id);
        await SeaborneCardTools.AcquireGem(EmeraldGemPower.Id);
        await SeaborneCardTools.AcquireGem(AmberGemPower.Id);
        await SeaborneCardTools.AcquireGem(OpalGemPower.Id);
        await SeaborneCardTools.AcquireGem(DiamondGemPower.Id);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        SeaborneCost = 0;
    }
}
