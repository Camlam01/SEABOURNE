using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers;

public abstract class SEABOURNEPower : CustomPowerModel
{
    public override string? CustomPackedIconPath
    {
        get
        {
            var path = $"{GetType().Name.Replace("Power", string.Empty).ToLowerInvariant()}.png".PowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".PowerImagePath();
        }
    }

    public override string? CustomBigIconPath
    {
        get
        {
            var path = $"{GetType().Name.Replace("Power", string.Empty).ToLowerInvariant()}.png".BigPowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".BigPowerImagePath();
        }
    }

    public override string? CustomBigBetaIconPath => CustomBigIconPath;

    protected object? OwnerRef => SeabourneReflection.GetProp(Owner, "Player", "Owner") ?? Owner;

    protected async Task DecayAtEndOfOwnerTurn(PlayerChoiceContext choiceContext, CombatSide side)
    {
        if (Owner is null || Owner.Side != side || Amount <= 0)
            return;

        if (Amount <= 1)
            await PowerCmd.Remove(this);
        else
            SetAmount(Amount - 1);
    }

    protected async Task GainBlockAsync(int amount)
    {
        if (Owner is null || amount <= 0)
            return;

        await SeabourneState.GainBlock(this, Owner, amount);
    }

    protected void GainEnergy(int amount)
    {
        if (amount <= 0 || OwnerRef is null)
            return;

        SeabourneState.GainEnergy(OwnerRef, amount);
    }

    protected int HandCount()
    {
        if (OwnerRef is null)
            return 0;

        return SeabourneReflection.GetHand(OwnerRef)?.Count ?? 0;
    }
}

public abstract class SeabourneGemPower : SEABOURNEPower
{
    protected abstract SeabourneGemType GemType { get; }

    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    public override Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        if (Owner is not null)
            SeabourneState.Gems(Owner).Acquire(GemType);

        return Task.CompletedTask;
    }

    public override Task AfterRemoved(Creature oldOwner)
    {
        var gems = SeabourneState.Gems(oldOwner);
        gems.Owned.Remove(GemType);
        gems.Charged.Remove(GemType);
        return Task.CompletedTask;
    }
}

public sealed class TemporaryStrengthPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override decimal ModifyDamageAdditive(Creature? target, decimal amount, MegaCrit.Sts2.Core.ValueProps.ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        return dealer == Owner && Amount > 0 ? Amount : 0m;
    }

    public override async Task AfterTurnEnd(PlayerChoiceContext choiceContext, CombatSide side)
    {
        if (Owner?.Side != side)
            return;

        await PowerCmd.Remove(this);
    }
}

public sealed class VulnerablePower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override decimal ModifyHpLostBeforeOsty(Creature target, decimal amount, MegaCrit.Sts2.Core.ValueProps.ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        return target == Owner && Amount > 0 ? decimal.Round(amount * 1.5m, 0, MidpointRounding.AwayFromZero) : amount;
    }

    public override Task AfterTurnEnd(PlayerChoiceContext choiceContext, CombatSide side) => DecayAtEndOfOwnerTurn(choiceContext, side);
}

public sealed class WeakPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override decimal ModifyDamageMultiplicative(Creature? target, decimal amount, MegaCrit.Sts2.Core.ValueProps.ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        return dealer == Owner && Amount > 0 ? 0.75m : 1m;
    }

    public override Task AfterTurnEnd(PlayerChoiceContext choiceContext, CombatSide side) => DecayAtEndOfOwnerTurn(choiceContext, side);
}

public sealed class StrengthPower : SEABOURNEPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override decimal ModifyDamageAdditive(Creature? target, decimal amount, MegaCrit.Sts2.Core.ValueProps.ValueProp props, Creature? dealer, CardModel? cardSource)
    {
        return dealer == Owner && Amount > 0 ? Amount : 0m;
    }
}
