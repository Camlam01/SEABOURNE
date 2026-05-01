namespace SEABOURNE.SEABOURNECode.Extensions;

public static class SEABOURNEPathExtensions
{
    public static string ImagePath(this string path)
    {
        return $"res://SEABOURNE/images/{path}";
    }

    public static string RelicImagePath(this string path)
    {
        return $"res://SEABOURNE/images/relics/{path}";
    }

    public static string PowerImagePath(this string path)
    {
        return $"res://SEABOURNE/images/powers/{path}";
    }

    public static string BigPowerImagePath(this string path)
    {
        return $"res://SEABOURNE/images/powers/big/{path}";
    }

    public static string CharacterUiPath(this string path)
    {
        return $"res://SEABOURNE/Characters/SEABOURNE/{path}";
    }
}
