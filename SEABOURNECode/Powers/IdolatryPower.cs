using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class IdolatryPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:Idolatry";

    public string Name => "Idolatry";
    public string Description => "Whenever you play a card with a modifier, damage all enemies.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/gem_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
