using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using SEABOURNE.SEABOURNECode.Extensions;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

public sealed class SeabourneStarterRelic : SeabourneRelic
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, MegaCrit.Sts2.Core.Entities.Players.Player player)
    {
        if (!ReferenceEquals(Owner, player))
            return;

        var creature = player.Creature;
        if (creature is null)
            return;

        if (SeabourneReflection.FindPower<CastPower>(creature) is { } cast)
        {
            SeabourneReflection.SetPowerAmount(cast, cast.Amount + 1, false);
            return;
        }

        ModelDb.Power<CastPower>().ToMutable().ApplyInternal(creature, 1, false);
        await Task.CompletedTask;
    }
}
