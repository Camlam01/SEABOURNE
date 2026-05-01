using BaseLib.Abstracts;
using BaseLib.Extensions;
using Godot;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers;

public abstract class SEABOURNEPower : CustomPowerModel
{
    public virtual bool ExpiresAtEndOfTurn => false;

    public virtual bool ExpiresAtStartOfPlayerTurn => false;

    public override string? CustomPackedIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".PowerImagePath();
        }
    }

    public override string? CustomBigIconPath
    {
        get
        {
            var path = $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
            return ResourceLoader.Exists(path) ? path : "power.png".BigPowerImagePath();
        }
    }

    public override string? CustomBigBetaIconPath => CustomBigIconPath;
}
