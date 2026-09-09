using BaseLib.Abstracts;
using Godot;

namespace SEABOURNE.SEABOURNECode.Pools;

/// <summary>
/// Potion pool for the Seabourne character. BaseLib automatically populates
/// this pool with custom potion models assigned to it.
/// </summary>
public class SeabournePotionPool : CustomPotionPoolModel
{
    public override Color LabOutlineColor => new(0.0f, 0.5f, 0.8f);
}
