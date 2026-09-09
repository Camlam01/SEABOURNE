using BaseLib.Abstracts;
using Godot;

namespace SEABOURNE.SEABOURNECode.Pools;

/// <summary>
/// Card pool for the Seabourne character. Custom Seabourne cards are added
/// to this pool through BaseLib's Pool attribute on the shared card base.
/// </summary>
public class SeabourneCardPool : CustomCardPoolModel
{
    public override string Title => "SEABOURNE";

    // Ocean-themed colour used for card frames and deck-entry card icons.
    public override Color ShaderColor => new(0.0f, 0.5f, 0.8f);
    public override Color DeckEntryCardColor => new(0.0f, 0.5f, 0.8f);

    public override bool IsColorless => false;
}
