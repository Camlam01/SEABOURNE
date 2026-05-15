using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class HeavyCannonballCard() : SeaborneCard(2, CardType.Attack, CardRarity.Uncommon, TargetType.Enemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(20m, ValueProp.Attack)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await Deal(play, Damage);
        await Apply(play, new StunPower(), 1);
    }

    protected override void OnUpgrade()
    {
        UpgradeDamage(10m);
    }
}
