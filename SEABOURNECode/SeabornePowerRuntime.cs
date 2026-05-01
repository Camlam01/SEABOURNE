using MegaCrit.Sts2.Core.Entities.Creatures;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Utils;

public static class SeabornePowerRuntime
{
    public static TPower? GetPower<TPower>(Creature? creature)
        where TPower : class
    {
        return creature?.Powers.OfType<TPower>().FirstOrDefault();
    }

    public static bool HasPower<TPower>(Creature? creature)
        where TPower : class
    {
        return GetPower<TPower>(creature) != null;
    }

    public static int Amount<TPower>(Creature? creature)
        where TPower : class
    {
        dynamic? power = GetPower<TPower>(creature);
        return power?.Amount ?? 0;
    }

    public static int ModifyBuffDebuffStacks(Creature? source, int baseStacks)
    {
        var stacks = baseStacks + (HasPower<EmeraldGemPower>(source) ? 1 : 0);
        var jinx = GetPower<JinxPower>(source);
        return jinx == null ? stacks : jinx.ModifyStacks(stacks);
    }

    public static int ModifyCast(Creature? source, int baseCast)
    {
        return baseCast + (HasPower<OpalGemPower>(source) ? 1 : 0);
    }

    public static int ModifyReel(Creature? source, int baseReel)
    {
        return baseReel
            + (HasPower<OpalGemPower>(source) ? 1 : 0)
            + Amount<MasterbaitPower>(source);
    }

    public static int ModifyWet(Creature? source, int baseWet)
    {
        return baseWet + (HasPower<DiamondGemPower>(source) ? 1 : 0);
    }

    public static decimal ModifyDamage(Creature? source, decimal damage)
    {
        return HasPower<SapphireGemPower>(source) ? Math.Ceiling(damage * 1.2m) : damage;
    }

    public static decimal ModifyBlock(Creature? source, decimal block)
    {
        return HasPower<RubyGemPower>(source) ? Math.Ceiling(block * 1.2m) : block;
    }
}
