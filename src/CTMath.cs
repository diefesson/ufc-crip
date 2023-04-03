namespace Diefesson.Cryptool;

public static class CTMath
{
    public static int Mod(int a, int b)
    {
        return (a >= 0) ? a % b : b + (a % b);
    }
}