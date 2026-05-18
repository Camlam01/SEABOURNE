using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class WaterwallPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override decimal ModifyHpLostBeforeOsty(Creature target, decimal amount, ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        if (Owner is null || target != Owner || Amount <= 0)
            return amount;

        var rounded = (int)decimal.Round(amount, 0, MidpointRounding.AwayFromZero);
        if (rounded <= 0 || rounded > Amount)
            return amount;

        SetAmount(Math.Max(0, Amount - rounded));
        return 0m;
    }

    public override async Task AfterTurnEnd(MegaCrit.Sts2.Core.GameActions.Multiplayer.PlayerChoiceContext choiceContext, CombatSide side)
    {
        if (Owner?.Side != side)
            return;

        await PowerCmd.Remove(this);
    }
}
