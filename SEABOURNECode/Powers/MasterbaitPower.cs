using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Powers;

namespace SEABOURNE.SEABOURNECode.Powers;

public sealed class MasterbaitPower : CustomPowerModel
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    public const string Id = "Seaborne:Masterbait";

    public string Name => "Masterbait";
    public string Description => "Whenever you Reel, Reel one more card.";
    public override string? CustomPackedIconPath => "res://SEABOURNE/images/cast_placeholder.png";
    public override string? CustomBigIconPath => CustomPackedIconPath;
    public override string? CustomBigBetaIconPath => CustomPackedIconPath;
}
