namespace Diefesson.Cryptool.Classic;

public static class CaesarBruteForce
{
    public static string[] bruteForce(string encrypted)
    {
        return Enumerable.Range(0, Consts.AlphabetLen).Select(key =>
        {
            var decrypter = new CaesarDecrypter(key);
            return String.Concat(encrypted.Select(decrypter.Decrypt));
        }).ToArray();
    }
}