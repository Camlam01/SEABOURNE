using System.Collections.Generic;
using Godot;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.PotionPools;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.Entities.Characters;

// Do not import BaseLib.Abstracts here.  The Seabourne mod ships with
// its own stub definitions for PlaceholderCharacterModel and related
// types in the MegaCrit.Sts2.Core.Models.Characters namespace.  Using
// BaseLib.Abstracts would introduce ambiguous references at compile
// time when the real API assemblies are absent.
using SEABOURNE.SEABOURNECode.Cards;
using SEABOURNE.SEABOURNECode.Pools;
using SEABOURNE.SEABOURNECode.Relics;

namespace SEABOURNE.SEABOURNECode.Characters
{
    /// <summary>
    /// The main character model for the Seabourne mod.  Inherits from
    /// PlaceholderCharacterModel and specifies all of the visual and gameplay
    /// properties required by Slay the Spire 2 to register a playable character.
    /// When compiled against the real game, the stub PlaceholderCharacterModel
    /// provided by the Seabourne mod will be replaced by the actual API class.
    /// </summary>
    public class SeabourneCharacter : MegaCrit.Sts2.Core.Models.Characters.PlaceholderCharacterModel
    {
        /// <summary>
        /// The starting hit points for Seabourne.  Adjust this value based on
        /// balance considerations.  A typical character like the Ironclad starts
        /// with 70 HP; feel free to modify as appropriate for your design.
        /// </summary>
        public override int StartingHp => 70;

        /// <summary>
        /// Base energy per turn.  Most characters start with 3 energy.  If
        /// Seabourne requires more or less, adjust accordingly.
        /// </summary>
        public override int StartingEnergy => 3;

        /// <summary>
        /// Colour of the character name in the UI.  Pick a colour that
        /// represents water or ocean themes.
        /// </summary>
        public override Color NameColor => new(0.0f, 0.5f, 0.8f);

        /// <summary>
        /// Colour of the energy label outline.  Use a complementary hue to
        /// differentiate the energy counter.  This should be distinct from
        /// NameColor to ensure readability on the UI.
        /// </summary>
        public override Color EnergyLabelOutlineColor => new(0.0f, 0.4f, 0.7f);

        /// <summary>
        /// Colour used to draw the character on the map.  Consistent with
        /// NameColor to maintain thematic coherence.
        /// </summary>
        public override Color MapDrawingColor => new(0.0f, 0.6f, 0.9f);

        /// <summary>
        /// Character gender used for text localization.  Modify if your
        /// character should use other pronouns.  The default is masculine.
        /// </summary>
        public override CharacterGender Gender => CharacterGender.Masculine;

        /// <summary>
        /// Path to the character select icon displayed when choosing a
        /// character.  Update this to match the actual asset location in
        /// your mod.  The path should be relative to the Godot project
        /// root (res://mods/SEABOURNE/...).
        /// </summary>
        public override string CustomCharacterSelectIconPath => "res://mods/SEABOURNE/images/charui/char_select_char_name.png";

        /// <summary>
        /// Path to the locked version of the character select icon.  Use
        /// the same icon for both locked and unlocked states if you do not
        /// provide a unique locked icon.
        /// </summary>
        public override string CustomCharacterSelectLockedIconPath => "res://mods/SEABOURNE/images/charui/char_select_char_name.png";

        /// <summary>
        /// Background scene used during character selection.  This tscn file
        /// should contain any visual elements you want to display behind the
        /// character portrait on the select screen.
        /// </summary>
        public override string CustomCharacterSelectBg => "res://mods/SEABOURNE/scenes/char_select_bg.tscn";

        /// <summary>
        /// Path to the icon texture used in some UI elements (e.g. relic
        /// tooltips).  Ensure the icon is square and sized appropriately.
        /// </summary>
        public override string CustomIconTexturePath => "res://mods/SEABOURNE/images/charui/character_icon_char_name.png";

        /// <summary>
        /// Path to the icon scene used in other UI elements.  This can be a
        /// simple Control node with an icon texture assigned.
        /// </summary>
        public override string CustomIconPath => "res://mods/SEABOURNE/scenes/character_icon_char_name.tscn";

        /// <summary>
        /// Path to the map marker icon used when showing the character on the
        /// world map.  This should be a small, easily recognisable icon.
        /// </summary>
        public override string CustomMapMarkerPath => "res://mods/SEABOURNE/images/charui/map_marker_char_name.png";

        /// <summary>
        /// Path to the main character visual used in-game.  This scene should
        /// contain the character's animations and attach points for weapons
        /// and effects.  Ensure the scene matches the expected Godot
        /// structure for characters.
        /// </summary>
        public override string CustomVisualPath => "res://mods/SEABOURNE/scenes/seabourne_character.tscn";

        /// <summary>
        /// Path to the merchant animation scene.  When interacting with
        /// merchants, this scene is used to display the character's idle
        /// animation.
        /// </summary>
        public override string CustomMerchantAnimPath => "res://mods/SEABOURNE/scenes/seabourne_merchant.tscn";

        /// <summary>
        /// Path to the rest site animation scene.  This scene should
        /// represent the character sitting by a campfire or resting.
        /// </summary>
        public override string CustomRestSiteAnimPath => "res://mods/SEABOURNE/scenes/seabourne_rest_site.tscn";

        /// <summary>
        /// Path to the energy counter scene.  Custom characters often have
        /// unique energy counters; update this to match your own asset.
        /// </summary>
        public override string CustomEnergyCounterPath => "res://mods/SEABOURNE/scenes/seabourne_energy_counter.tscn";

        /// <summary>
        /// Path to the sound played when the character is selected from the
        /// character select screen.  Use a relevant audio asset from your
        /// mod.
        /// </summary>
        public override string CharacterSelectSfx => "res://mods/SEABOURNE/sound/character_select.wav";

        /// <summary>
        /// Specifies the default card pool for Seabourne.  It uses
        /// ModelDb.CardPool to instantiate the custom card pool model.
        /// </summary>
        public override CardPoolModel CardPool => ModelDb.CardPool<SeabourneCardPool>();

        /// <summary>
        /// Specifies the default relic pool for Seabourne.  Uses
        /// ModelDb.RelicPool to retrieve the custom relic pool model.
        /// </summary>
        public override RelicPoolModel RelicPool => ModelDb.RelicPool<SeabourneRelicPool>();

        /// <summary>
        /// Specifies the default potion pool for Seabourne.  Uses
        /// ModelDb.PotionPool to retrieve the custom potion pool model.
        /// </summary>
        public override PotionPoolModel PotionPool => ModelDb.PotionPool<SeabournePotionPool>();

        /// <summary>
        /// Defines the starting deck for Seabourne.  Adjust the card
        /// composition to reflect your character's unique mechanics.  Here we
        /// provide a simple example with two Fish cards, one Fire Cannon and
        /// three Defend cards.  Replace these card types with the actual
        /// classes from your mod.
        /// </summary>
        public override IEnumerable<CardModel> StartingDeck => new List<CardModel>
        {
            ModelDb.Card<Fish>(),
            ModelDb.Card<Fish>(),
            ModelDb.Card<FireCannon>(),
            ModelDb.Card<Defend>(),
            ModelDb.Card<Defend>(),
            ModelDb.Card<Defend>()
        };

        /// <summary>
        /// Defines the relics given to Seabourne at the start of a run.  At
        /// minimum, characters usually receive one starter relic.  Replace
        /// SeabourneStarterRelic with the name of your custom relic class.
        /// </summary>
        public override IReadOnlyList<RelicModel> StartingRelics => new List<RelicModel>
        {
            ModelDb.Relic<SeabourneStarterRelic>()
        };
    }
}