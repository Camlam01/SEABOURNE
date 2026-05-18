using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Powers
{
    /// <summary>
    /// Sorcerer Form grants all cards imbued 1 while it is active.  This stub
    /// defines the power type and stack type.  Game logic may be added later
    /// as needed.
    /// </summary>
    public sealed class SorcererFormPower : SEABOURNEPower
    {
        public override PowerType Type => PowerType.Buff;
        public override PowerStackType StackType => PowerStackType.Single;

        /// <summary>
        /// When applied, mark all cards in the player's deck as imbued.  This
        /// stub does not implement the full behaviour but compiles.  Real
        /// implementation should override hooks and modify <see cref="CardModel"/>
        /// accordingly.
        /// </summary>
    }
}