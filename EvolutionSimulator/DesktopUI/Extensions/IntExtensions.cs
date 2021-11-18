namespace DesktopUI.Extensions;
public static class IntExtensions
{
    public static int LeastCommonMultiple(this int a, int b) => lcm(a, b);

    public static int GreatestCommonDenominator(this int a, int b) => gcd(a, b);

    private static int gcd(int a, int b)
    {
        if (a == 0)
            return b;
        return gcd(b % a, a);
    }

    private static int lcm(int a, int b)
    {
        return (a / gcd(a, b)) * b;
    }
}
