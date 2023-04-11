namespace Diefesson.Cryptool;

public static class ClassicMath
{

    public const int AlphabetLen = 'Z' - 'A' + 1;

    public static int Mod(int a, int b)
    {
        return (a >= 0) ? a % b : b + (a % b);
    }

    public static int C2I(char c)
    {
        return Char.ToUpper(c) - 'A';
    }

    public static char I2C(int i)
    {
        return Char.ToUpper((char)(i + 'A'));
    }

    public static char Rot(char c, int shift, bool keepCase = true)
    {
        var lower = keepCase & Char.IsLower(c);
        var r = I2C(Mod(C2I(c) + shift, AlphabetLen));
        return (lower) ? Char.ToLower(r) : r;
    }
}