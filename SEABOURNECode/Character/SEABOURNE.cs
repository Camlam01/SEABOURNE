using System.Collections.Generic;
using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using SEABOURNE.SEABOURNECode.Cards;
using SEABOURNE.SEABOURNECode.Relics;

namespace SEABOURNE.SEABOURNECode.Character;

public sealed class TheSeaborne : CustomCharacterModel
{
    public const string CharacterId = "TheSeaborne";
    public static readonly Color Color = new("1b7f9c");

    public override Color NameColor => Color;
    public override Color MapDrawingColor => Color;
    public override CharacterGender Gender => CharacterGender.Feminine;
    public override int StartingHp => 75;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<FishCard>(),
        ModelDb.Card<FireCannonCard>(),
        ModelDb.Card<SplashingStrikeCard>(),
        ModelDb.Card<RodRamCard>(),
        ModelDb.Card<WhiplashCard>(),
        ModelDb.Card<PullThroughCard>(),
        ModelDb.Card<SirenSongCard>(),
        ModelDb.Card<TackleCard>(),
        ModelDb.Card<TackleCard>(),
        ModelDb.Card<RiptideCard>(),
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<TrustyFishingRodRelic>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<SEABOURNECardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<SEABOURNERelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<SEABOURNEPotionPool>();

    public override List<string> GetArchitectAttackVfx() =>
    [
        "vfx/vfx_attack_slash",
        "vfx/vfx_attack_blunt",
        "vfx/vfx_heavy_blunt",
        "vfx/vfx_bloody_impact",
    ];

    public override string CustomVisualPath => "res://SEABOURNE/Characters/SEABOURNE/seaborne_character.tscn";
    public override string CustomTrailPath => "res://scenes/vfx/card_trail_ironclad.tscn";
    public override string CustomIconPath => "res://SEABOURNE/Characters/SEABOURNE/seaborne_character_icon.tscn";
    public override string CustomIconTexturePath => "res://SEABOURNE/images/seaborne_placeholder.png";
    public override string CustomRestSiteAnimPath => "res://SEABOURNE/Characters/SEABOURNE/seaborne_character_rest_site.tscn";
    public override string CustomMerchantAnimPath => "res://SEABOURNE/Characters/SEABOURNE/seaborne_character_merchant.tscn";
    public override string CustomCharacterSelectBg => "res://SEABOURNE/Characters/SEABOURNE/char_select_bg_seaborne_character.tscn";
    public override string CustomCharacterSelectIconPath => "res://SEABOURNE/images/seaborne_placeholder.png";
    public override string CustomCharacterSelectLockedIconPath => "res://SEABOURNE/images/seaborne_placeholder.png";
    public override string CustomCharacterSelectTransitionPath => "res://materials/transitions/ironclad_transition_mat.tres";
    public override string CustomMapMarkerPath => "res://SEABOURNE/images/seaborne_placeholder.png";
    public override string? CustomEnergyCounterPath => "res://scenes/combat/energy_counters/ironclad_energy_counter.tscn";
}

public sealed class SEABOURNECardPool : CustomCardPoolModel
{
    public override string Title => SEABOURNE.CharacterId;
    public override float H => 0.52f;
    public override float S => 0.75f;
    public override float V => 0.85f;
    public override Color DeckEntryCardColor => SEABOURNE.Color;
    public override bool IsColorless => false;
    public override string? BigEnergyIconPath => null;
    public override string? TextEnergyIconPath => null;
}

public sealed class SEABOURNERelicPool : CustomRelicPoolModel
{
    public override string EnergyColorName => SEABOURNE.CharacterId;
}

public sealed class SEABOURNEPotionPool : CustomPotionPoolModel
{
    public override string EnergyColorName => SEABOURNE.CharacterId;
}
