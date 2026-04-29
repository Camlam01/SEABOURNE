using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class ShardyShrapnelPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:ShardyShrapnel";

    public string Name => "Shardy Shrapnel";
    public string Description => "Cannon shots deal additional shrapnel damage.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/cannon_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
