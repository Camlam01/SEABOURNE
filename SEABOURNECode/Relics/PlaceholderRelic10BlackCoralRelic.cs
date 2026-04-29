using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Relics;
using BaseLib.Utils;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Utils;

namespace SEABOURNE.SEABOURNECode.Relics;

[Pool(typeof(SEABOURNERelicPool))]
public sealed class PlaceholderRelic10BlackCoralRelic : CustomRelicModel
{
    public override RelicRarity Rarity => RelicRarity.Rare;
    public string Name => "Placeholder Relic 10";
    public string Description => "At the start of each turn, apply 1 Trance to all enemies.";
    public override string PackedIconPath => "res://SEABOURNE/images/relic_placeholder.png";
    protected override string PackedIconOutlinePath => PackedIconPath;
    protected override string BigIconPath => PackedIconPath;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        foreach (object enemy in SeaborneReflectionTools.GetEnemies())
        {
            await SeaborneCardTools.ApplyTrance(enemy, 1);
        }
    }
}
