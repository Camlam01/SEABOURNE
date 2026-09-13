using BaseLib.Abstracts;
using BaseLib.Patches.Content;
using Godot;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;

namespace SEABOURNE.SEABOURNECode.Cannon;

/// <summary>The combat-only pile containing cannonballs in load order.</summary>
public sealed class LoadedCannonPile() : CustomPile(Loaded)
{
    [CustomEnum]
    public static PileType Loaded;

    public override bool CardShouldBeVisible(CardModel card) => false;

    public override Vector2 GetTargetPosition(CardModel model, Vector2 size)
        => new(size.X / 2f, size.Y);
}
