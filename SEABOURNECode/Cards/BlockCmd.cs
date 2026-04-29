using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;

namespace SEABOURNE.SEABOURNECode.Cards;

public static class BlockCmd
{
    public static SeaborneBlockCommand Gain(decimal amount)
    {
        return new SeaborneBlockCommand(amount);
    }
}

public sealed class SeaborneBlockCommand
{
    private readonly decimal _amount;
    private SeaborneCard? _source;

    public SeaborneBlockCommand(decimal amount)
    {
        _amount = amount;
    }

    public SeaborneBlockCommand FromCard(SeaborneCard source)
    {
        _source = source;
        return this;
    }

    public async Task Execute(PlayerChoiceContext choiceContext)
    {
        if (_source?.Owner?.Creature is null)
        {
            return;
        }

        await CreatureCmd.GainBlock(_source.Owner.Creature, new BlockVar(_amount, ValueProp.Move), null, false);
    }
}
