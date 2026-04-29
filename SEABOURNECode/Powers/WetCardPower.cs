using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class WetCardPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:Wet";

    public string Name => "Wet";
    public string Description => "This card can trigger its Wet effect when reeled. This does not count as playing it.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/wet_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
