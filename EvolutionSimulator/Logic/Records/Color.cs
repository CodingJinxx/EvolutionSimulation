namespace Logic.Records;

public record Color(int R, int G, int B);

public static class ColorExtensions
{
    private static Random r = new Random();

    public static string ToHex(this Color color)
    {
        string output = "#";
        output += color.R.ToString("X2");
        output += color.G.ToString("X2");
        output += color.B.ToString("X2");
        return output;
    }

    public static Color Random(this Color color)
    {
        return new Color(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
    }
}
