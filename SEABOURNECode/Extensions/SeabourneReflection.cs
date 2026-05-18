using System.Collections;
using System.Reflection;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Extensions;

internal static class SeabourneReflection
{
    private static readonly BindingFlags Flags =
        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    public static object? GetProp(object? obj, params string[] names)
    {
        if (obj is null)
            return null;

        var type = obj.GetType();
        foreach (var name in names)
        {
            var prop = type.GetProperty(name, Flags);
            if (prop is not null)
                return prop.GetValue(obj);

            var field = type.GetField(name, Flags);
            if (field is not null)
                return field.GetValue(obj);
        }

        return null;
    }

    public static T? GetProp<T>(object? obj, params string[] names)
    {
        var value = GetProp(obj, names);
        return value is T typed ? typed : default;
    }

    public static object? Invoke(object? obj, string name, params object?[] args)
    {
        if (obj is null)
            return null;

        var method = obj.GetType()
            .GetMethods(Flags)
            .FirstOrDefault(m => m.Name == name && ArgsMatch(m.GetParameters(), args));

        return method?.Invoke(obj, args);
    }

    public static object? GetPlayer(CardModel card) => GetProp(card, "Owner", "Player");

    public static object? GetPlayer(CardPlay play)
    {
        var card = GetProp<CardModel>(play, "Card", "CardModel");
        return card is null ? null : GetPlayer(card);
    }

    public static Creature? GetCreature(CardModel card)
    {
        var owner = GetPlayer(card);
        return GetProp<Creature>(owner, "Creature", "OwnerCreature", "PlayerCreature")
               ?? GetProp<Creature>(card, "Creature", "OwnerCreature");
    }

    public static Creature? GetCreature(CardPlay play)
    {
        var card = GetProp<CardModel>(play, "Card", "CardModel");
        return card is null ? null : GetCreature(card);
    }

    public static Creature? GetOwner(CardModel card) => GetCreature(card);

    public static Creature? GetOwner(CardPlay play) => GetCreature(play);

    public static Creature? GetTarget(CardPlay play)
    {
        return GetProp<Creature>(play, "Target", "PrimaryTarget")
               ?? GetProp<Creature>(GetProp(play, "ChoiceContext"), "Target")
               ?? GetProp<Creature>(play, "SelectedTarget");
    }

    public static IList? GetPile(object? owner, params string[] pileNames)
    {
        var player = NormalizePileOwner(owner);
        if (player is null)
            return null;

        foreach (var pileName in pileNames)
        {
            var pile = GetProp(player, pileName);
            if (pile is IList list)
                return list;

            var cards = GetProp(pile, "Cards", "Items");
            if (cards is IList nestedList)
                return nestedList;
        }

        return null;
    }

    public static IList? GetHand(object? owner) => GetPile(owner, "Hand", "HandPile");

    public static IList? GetDiscard(object? owner) => GetPile(owner, "DiscardPile", "Discard", "DiscardCards");

    public static IList? GetDraw(object? owner) => GetPile(owner, "DrawPile", "Draw", "Deck");

    public static IEnumerable<Creature> GetEnemies(object? owner)
    {
        var combat = GetProp(owner, "CombatState", "Combat", "CurrentCombat")
                     ?? GetProp(GetCreatureFromAny(owner), "CombatState", "Combat", "CurrentCombat");

        var enemies = GetProp(combat, "Enemies", "EnemyCreatures");
        return enemies is IEnumerable enumerable ? enumerable.OfType<Creature>() : Array.Empty<Creature>();
    }

    public static IEnumerable GetRelics(object? owner)
    {
        var player = NormalizePileOwner(owner);
        var relics = GetProp(player, "Relics", "OwnedRelics");
        return relics is IEnumerable enumerable ? enumerable.Cast<object>() : Array.Empty<object>();
    }

    public static IEnumerable GetPowers(object? owner)
    {
        var creature = GetCreatureFromAny(owner);
        var powers = GetProp(creature, "Powers", "AllPowers");
        return powers is IEnumerable enumerable ? enumerable.Cast<object>() : Array.Empty<object>();
    }

    public static TPower? FindPower<TPower>(object? owner)
        where TPower : class
    {
        return GetPowers(owner).OfType<TPower>().FirstOrDefault();
    }

    public static int GetInt(object? obj, params string[] names)
    {
        var value = GetProp(obj, names);
        return value switch
        {
            int i => i,
            decimal d => (int)d,
            float f => (int)f,
            double dbl => (int)dbl,
            long l => (int)l,
            _ => 0,
        };
    }

    public static decimal GetDecimal(object? obj, params string[] names)
    {
        var value = GetProp(obj, names);
        return value switch
        {
            decimal d => d,
            int i => i,
            float f => (decimal)f,
            double dbl => (decimal)dbl,
            long l => l,
            _ => 0m,
        };
    }

    public static bool HasMethod(object? obj, string name)
    {
        return obj is not null && obj.GetType().GetMethod(name, Flags) is not null;
    }

    public static void RemoveFromList(IList? list, object item)
    {
        if (list is null)
            return;

        if (list.Contains(item))
            list.Remove(item);
    }

    public static void AddToList(IList? list, object item)
    {
        list?.Add(item);
    }

    public static bool IsHandFull(object? owner)
    {
        var player = NormalizePileOwner(owner);
        var hand = GetHand(player);
        if (hand is null)
            return false;

        var maxHandSize = GetInt(player, "MaxHandSize", "HandSizeLimit");
        if (maxHandSize <= 0)
            maxHandSize = 10;

        return hand.Count >= maxHandSize;
    }

    public static async Task ExecuteCommand(object? command, PlayerChoiceContext choiceContext)
    {
        if (command is null)
            return;

        var methods = command.GetType()
            .GetMethods(Flags)
            .Where(m => m.Name == "Execute")
            .OrderByDescending(m => m.GetParameters().Length)
            .ToList();

        foreach (var method in methods)
        {
            var parameters = method.GetParameters();
            if (!ArgsMatch(parameters, [choiceContext]))
                continue;

            var result = method.Invoke(command, [choiceContext]);
            if (result is Task task)
                await task;

            return;
        }

        foreach (var method in methods)
        {
            var parameters = method.GetParameters();
            if (!ArgsMatch(parameters, Array.Empty<object?>()))
                continue;

            var result = method.Invoke(command, Array.Empty<object?>());
            if (result is Task task)
                await task;

            return;
        }

        throw new MissingMethodException(command.GetType().FullName, "Execute");
    }

    public static void SetPowerAmount(PowerModel power, int amount, bool silent = false)
    {
        var method = power.GetType()
            .GetMethods(Flags)
            .FirstOrDefault(m => m.Name == "SetAmount" && ArgsMatch(m.GetParameters(), [amount, silent]));

        if (method is not null)
        {
            method.Invoke(power, [amount, silent]);
            return;
        }

        power.ApplyInternal(power.Owner, amount - power.Amount, silent);
    }

    private static object? NormalizePileOwner(object? owner)
    {
        if (owner is null)
            return null;

        if (GetHandDirect(owner) is not null || GetDiscardDirect(owner) is not null || GetDrawDirect(owner) is not null)
            return owner;

        return GetProp(owner, "Player", "Owner", "CardOwner");
    }

    private static Creature? GetCreatureFromAny(object? owner)
    {
        return owner as Creature
               ?? GetProp<Creature>(owner, "Creature", "OwnerCreature", "PlayerCreature")
               ?? GetProp<Creature>(GetProp(owner, "Player", "Owner"), "Creature", "OwnerCreature", "PlayerCreature");
    }

    private static object? GetHandDirect(object obj) => GetProp(obj, "Hand", "HandPile");

    private static object? GetDiscardDirect(object obj) => GetProp(obj, "DiscardPile", "Discard", "DiscardCards");

    private static object? GetDrawDirect(object obj) => GetProp(obj, "DrawPile", "Draw", "Deck");

    private static bool ArgsMatch(ParameterInfo[] parameters, object?[] args)
    {
        if (parameters.Length != args.Length)
            return false;

        for (var i = 0; i < parameters.Length; i++)
        {
            var argument = args[i];
            var parameterType = parameters[i].ParameterType;

            if (argument is null)
            {
                if (parameterType.IsValueType && Nullable.GetUnderlyingType(parameterType) is null)
                    return false;

                continue;
            }

            if (!parameterType.IsInstanceOfType(argument))
                return false;
        }

        return true;
    }
}
