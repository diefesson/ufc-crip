namespace Diefesson.Cryptool.Classic;

public static class CaesarBruteForce
{
    public static string[] bruteForce(string encrypted)
    {
        return Enumerable
            .Range(0, ClassicMath.AlphabetLen)
            .Select(k => Caesar.Decrypt(encrypted, k))
            .ToArray();
    }
}