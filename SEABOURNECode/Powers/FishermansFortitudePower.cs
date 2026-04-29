using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class FishermansFortitudePower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:FishermansFortitude";

    public string Name => "Fisherman's Fortitude";
    public string Description => "Gain Block whenever you Reel.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/cast_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
