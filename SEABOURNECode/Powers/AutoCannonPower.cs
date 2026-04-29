using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class AutoCannonPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:AutoCannon";

    public string Name => "Auto Cannon";
    public string Description => "Fire the cannon at the start of your turn.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/cannon_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
