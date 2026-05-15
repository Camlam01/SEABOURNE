using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class BejeweledStrikeCard() : SeaborneCard(1, CardType.Attack, CardRarity.Rare, TargetType.Enemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(10m, ValueProp.Attack)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Deal(play, Damage);
        await Gain(play, new GemSlotPower(), 1);
        await Acquire(play, Random.Shared.Next(3) switch { 0 => new RubyGemPower(), 1 => new SapphireGemPower(), _ => new EmeraldGemPower() });
    }

    protected override void OnUpgrade()
    {
        UpgradeDamage(5m);
    }
}
