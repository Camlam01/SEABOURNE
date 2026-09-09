using BaseLib.Abstracts;
using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using SEABOURNE.SEABOURNECode.Pools;

namespace SEABOURNE.SEABOURNECode.Cards
{
    /// <summary>
    /// Base class for all Seabourne cards using the current BaseLib card API.
    /// Individual cards supply cost, type, rarity and target through their
    /// primary constructor and are automatically associated with the
    /// Seabourne card pool.
    /// </summary>
    [Pool(typeof(SeabourneCardPool))]
    public abstract class SeabourneCard(int cost, CardType type, CardRarity rarity, TargetType target)
        : CustomCardModel(cost, type, rarity, target)
    {
    }
}
