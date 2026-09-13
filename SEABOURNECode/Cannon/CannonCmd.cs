using BaseLib.Patches.Content;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Cannon;

public static class CannonCmd
{
    public static IReadOnlyList<CardModel> Loaded(Player player)
        => CustomPiles.GetCustomPile(player.PlayerCombatState, LoadedCannonPile.Loaded)?.Cards
            ?? [];

    /// <summary>Fires every loaded cannonball, oldest first.</summary>
    public static async Task Fire(PlayerChoiceContext choiceContext, Player player, Creature? target)
    {
        // Snapshot the pile because AutoPlay moves each resolved card to discard.
        if (target is null)
        {
            return;
        }

        foreach (CardModel cannonball in Loaded(player).ToList())
        {
            await CardCmd.AutoPlay(choiceContext, cannonball, target);
        }
    }
}
