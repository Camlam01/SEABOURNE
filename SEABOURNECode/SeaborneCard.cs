using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using SEABOURNE.SEABOURNECode.Character;

namespace SEABOURNE.SEABOURNECode.Cards;

[Pool(typeof(SEABOURNECardPool))]
public abstract class SeaborneCard(
    int cost,
    CardType type,
    CardRarity rarity,
    TargetType target
) : CustomCardModel(cost, type, rarity, target)
{
    public override string PortraitPath =>
        "res://SEABOURNE/images/card_placeholder.png";

    public override string BetaPortraitPath => PortraitPath;
}
