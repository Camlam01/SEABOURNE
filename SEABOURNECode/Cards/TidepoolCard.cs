using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using SEABOURNE.SEABOURNECode.Powers;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Cards;

public class TidepoolCard() : SeaborneCard(3, CardType.Attack, CardRarity.Rare, TargetType.AllEnemies), ISeaborneWetCard
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(5m, ValueProp.Attack)];

    private int waterwall = 5;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await DealAll(play, Damage);
        await Gain(play, new WaterwallPower(), waterwall);
        await ApplyAll(play, new WeakPower(), 1);
        await ApplyAll(play, new VulnerablePower(), 1);
        await SeaborneCardRuntime.AddCopyToDiscard(play, new TidepoolCard());
        await Gain(play, new WetCardPower(), 1);
    }

    protected override void OnUpgrade()
    {
        base.OnUpgrade();
    }

    public async Task OnReeled(CardPlay play)
    {
        await DealAll(play, Damage);
        await Gain(play, new WaterwallPower(), waterwall);
        await ApplyAll(play, new WeakPower(), 1);
        await ApplyAll(play, new VulnerablePower(), 1);
        await SeaborneCardRuntime.AddCopyToDiscard(play, new TidepoolCard());
    }
}
