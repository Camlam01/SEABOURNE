using BaseLib.Abstracts;
using BaseLib.Utils;
using Godot;
using SEABOURNE.SEABOURNECode.Character;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Relics;

[Pool(typeof(SEABOURNERelicPool))]
public abstract class SeaborneRelic : CustomRelicModel
{
    public override string? CustomIconPath
    {
        get
        {
            var fileName = $"{GetType().Name.Replace("Relic", string.Empty).ToLowerInvariant()}.png";
            var path = fileName.RelicImagePath();
            return ResourceLoader.Exists(path) ? path : "relic_placeholder.png".RelicImagePath();
        }
    }
}
