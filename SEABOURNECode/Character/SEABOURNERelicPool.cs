using BaseLib.Abstracts;
using Godot;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Character
{
    public class SEABOURNERelicPool : CustomRelicPoolModel
    {
        public override Color LabOutlineColor => SEABOURNE.Color;

        public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
        public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
    }
}