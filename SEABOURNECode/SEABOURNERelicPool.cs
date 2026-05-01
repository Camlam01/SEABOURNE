using BaseLib.Abstracts;
using Godot;

namespace SEABOURNE.SEABOURNECode.Character;

public sealed class SEABOURNERelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => TheSeaborne.CharacterId;

    public override Color LabOutlineColor => TheSeaborne.Color;
}
