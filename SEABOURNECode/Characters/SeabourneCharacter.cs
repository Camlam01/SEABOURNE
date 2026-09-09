using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using SEABOURNE.SEABOURNECode.Cards.Starter;
using SEABOURNE.SEABOURNECode.Pools;

namespace SEABOURNE.SEABOURNECode.Characters;

/// <summary>
/// Playable Seabourne character model.
///
/// While the mod is being brought onto the current STS2/BaseLib API, the
/// character intentionally relies on PlaceholderCharacterModel for its visual,
/// animation, energy-counter and audio assets. Custom Seabourne assets can be
/// reintroduced once the code-side vertical slice is loading reliably.
/// </summary>
public class SeabourneCharacter : PlaceholderCharacterModel
{
    public static readonly Color Color = new(0.0f, 0.5f, 0.8f);

    public override Color NameColor => Color;
    public override Color EnergyLabelOutlineColor => new(0.0f, 0.4f, 0.7f);
    public override Color MapDrawingColor => new(0.0f, 0.6f, 0.9f);

    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 70;
    public override int MaxEnergy => 3;

    public override CardPoolModel CardPool => ModelDb.CardPool<SeabourneCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<SeabourneRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<SeabournePotionPool>();

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<Fish_Seabourne>(),
        ModelDb.Card<Fish_Seabourne>(),
        ModelDb.Card<FireCannon_Seabourne>(),
        ModelDb.Card<Defend_Seabourne>(),
        ModelDb.Card<Defend_Seabourne>(),
        ModelDb.Card<Defend_Seabourne>()
    ];

    // Temporary compile-safe starter relic while SeabourneStarterRelic is
    // migrated to the current BaseLib relic API.
    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<BurningBlood>()
    ];
}
