using BaseLib.Abstracts;
using Godot;

namespace SEABOURNE.SEABOURNECode.Pools;

/// <summary>
/// Relic pool for the Seabourne character. BaseLib automatically populates
/// this pool with custom relic models assigned to it.
/// </summary>
public class SeabourneRelicPool : CustomRelicPoolModel
{
    public override Color LabOutlineColor => new(0.0f, 0.5f, 0.8f);
}
