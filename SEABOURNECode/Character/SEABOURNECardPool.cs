using BaseLib.Abstracts;
using BaseLib.Utils;
using Godot;
using MegaCrit.Sts2.Core.Assets;
using SEABOURNE.SEABOURNECode.Extensions;

namespace SEABOURNE.SEABOURNECode.Character;

public sealed class SEABOURNECardPool : CustomCardPoolModel
{
    public override string Title => TheSeaborne.CharacterId;
    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
    public override float H => 0.58f;
    public override float S => 0.75f;
    public override float V => 0.95f;
    public override Color DeckEntryCardColor => new("4FB8FF");
    public override bool IsColorless => false;

    public override Texture2D CustomFrame(CustomCardModel card)
    {
        return PreloadManager.Cache.GetTexture2D("images/cards/card_frame.png");
    }
}
