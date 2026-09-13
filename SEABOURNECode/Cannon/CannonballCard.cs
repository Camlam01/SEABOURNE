using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Cards;

namespace SEABOURNE.SEABOURNECode.Cannon;

/// <summary>
/// A cannonball loads on a manual play and resolves its payload when the
/// cannon auto-plays it. The result-pile hook keeps manually played balls in
/// the cannon and sends fired balls to discard.
/// </summary>
public abstract class CannonballCard(int cost, CardRarity rarity)
    : SeabourneCard(cost, CardType.Attack, rarity, TargetType.AnyEnemy)
{
    protected sealed override Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
        => play.IsAutoPlay ? OnFire(choiceContext, play) : Task.CompletedTask;

    protected virtual Task OnFire(PlayerChoiceContext choiceContext, CardPlay play)
        => CommonActions.CardAttack(this, play).Execute(choiceContext);

    public override (PileType, CardPilePosition) ModifyCardPlayResultPileTypeAndPosition(
        CardModel card,
        bool isAutoPlay,
        ResourceInfo resources,
        PileType pileType,
        CardPilePosition position)
    {
        if (card == this && !isAutoPlay)
        {
            return (LoadedCannonPile.Loaded, CardPilePosition.Bottom);
        }

        return base.ModifyCardPlayResultPileTypeAndPosition(
            card, isAutoPlay, resources, pileType, position);
    }
}
