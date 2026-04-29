using BaseLib.Abstracts;
using BaseLib.Extensions;
using Godot;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Powers
{
    public abstract class SEABOURNEPower : CustomPowerModel
    {
        //Loads from SEABOURNE/images/powers/your_power.png
        public override string CustomPackedIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PowerImagePath();
        public override string CustomBigIconPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigPowerImagePath();
    }
}