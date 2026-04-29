using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public sealed class FireCannonCard : SeaborneCard
{
    public override bool HasAttackDamage => true;
    public FireCannonCard() : base(2, CardType.Skill, CardRarity.Basic, TargetType.AnyEnemy) { }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await ApplySeaborneGemModifiers();
        await SeaborneCardTools.FireCannon(choiceContext, cardPlay, this);
        await ApplyGemWetIfAny();
    }

    protected override void OnUpgrade()
    {
        SeaborneCost = 1;
    }
}
