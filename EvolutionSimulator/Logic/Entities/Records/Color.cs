using System.Runtime.CompilerServices;

namespace Logic.Entities.Records;

public record Color(int R, int G, int B);

public static class ColorExtensions
{
    public static string ToHex(this Color color)
    {
        string output = "#";
        output += color.R.ToString("X2");
        output += color.G.ToString("X2");
        output += color.B.ToString("X2");
        return output;
    }
}
