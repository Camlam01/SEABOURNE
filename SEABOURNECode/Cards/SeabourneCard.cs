using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using SEABOURNE.SEABOURNECode.Pools;

namespace SEABOURNE.SEABOURNECode.Cards;

/// <summary>
/// Base class for all Seabourne cards using the current BaseLib card API.
/// Card text remains defined inline on each card for now, and is exposed to
/// STS2 through BaseLib's in-code CardLoc localization support.
/// </summary>
[Pool(typeof(SeabourneCardPool))]
public abstract class SeabourneCard(int cost, CardType type, CardRarity rarity, TargetType target)
    : CustomCardModel(cost, type, rarity, target)
{
    public abstract string Name { get; }

    // CardModel.Description is a localized, non-virtual property. Hide it on
    // this intermediate base so the existing card definitions can continue to
    // supply their source text while BaseLib publishes it as localization.
    public new abstract string Description { get; }

    public override List<(string, string)>? Localization => new CardLoc(Name, Description);
}
