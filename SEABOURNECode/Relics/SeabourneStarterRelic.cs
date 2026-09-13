using BaseLib.Abstracts;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using SEABOURNE.SEABOURNECode.Pools;
using SEABOURNE.SEABOURNECode.Powers;

namespace SEABOURNE.SEABOURNECode.Relics;

[Pool(typeof(SeabourneRelicPool))]
public class SeabourneStarterRelic() : CustomRelicModel
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    public override List<(string, string)>? Localization => new RelicLoc(
        "Old Fishing Rod",
        "At the start of each turn, gain 1 Cast.",
        "The line always finds its way back.");

    public override async Task AfterEnergyResetLate(Player player)
    {
        if (player != Owner)
            return;

        Flash();
        await PowerCmd.Apply<CastPower>(
            new ThrowingPlayerChoiceContext(),
            Owner.Creature,
            1m,
            Owner.Creature,
            null);
    }
}
