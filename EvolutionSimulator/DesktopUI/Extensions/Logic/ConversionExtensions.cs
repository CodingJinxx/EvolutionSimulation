using LogicColor = Logic.Records.Color;
using RaylibColor = Raylib_cs.Color;

namespace DesktopUI.Extensions.Logic;

public static class ConversionExtensions
{
    public static RaylibColor ToRaylibColor(this LogicColor color)
    {
        return new RaylibColor(color.R, color.G, color.B, 255);
    }
}