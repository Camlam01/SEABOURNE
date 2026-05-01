using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class FireAndWaterCard() : SeaborneCard(1, CardType.Attack, CardRarity.Uncommon, TargetType.Enemy)
{
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Innate];

    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(5m, ValueProp.Attack), new BlockVar(5m, ValueProp.Block)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Deal(play, Damage);
        await GainBlock(play, Block);
        await Acquire(play, Random.Shared.Next(2) == 0 ? new RubyGemPower() : new SapphireGemPower());
    }

    protected override void OnUpgrade()
    {
        base.OnUpgrade();
    }
}
