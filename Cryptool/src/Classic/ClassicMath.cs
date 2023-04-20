namespace Diefesson.Cryptool.Classic;

public static class ClassicMath
{

    public static readonly IReadOnlyList<char> Alphabet = (IReadOnlyList<char>)Enumerable
        .Range('A', 'Z' - 'A' + 1)
        .Select(c => (char)c)
        .ToArray()
        .AsReadOnly();

    public static int Mod(int a, int b)
    {
        return (a >= 0) ? a % b : b + (a % b);
    }

    public static int C2I(char c)
    {
        return Char.ToUpper(c) - 'A';
    }

    public static char I2C(int i, bool lower = false)
    {
        var c = (char)('A' + i);
        return lower ? Char.ToLower(c) : c;
    }

    public static char Rot(char c, int shift, bool keepCase = true)
    {
        var lower = keepCase && Char.IsLower(c);
        var r = I2C(Mod(C2I(c) + shift, Alphabet.Count), lower);
        return r;
    }
}