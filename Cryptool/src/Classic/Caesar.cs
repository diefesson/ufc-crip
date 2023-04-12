namespace Diefesson.Cryptool.Classic;

public static class Caesar
{
    public static string Encrypt(string plaintext, int key)
    {
        var ciphertext = plaintext.Select(c => (Char.IsAsciiLetter(c)) ? ClassicMath.Rot(c, key) : c);
        return String.Concat(ciphertext);
    }

    public static string Decrypt(string ciphertext, int key)
    {
        var plaintext = ciphertext.Select(c => (Char.IsAsciiLetter(c)) ? ClassicMath.Rot(c, -key) : c);
        return String.Concat(plaintext);
    }
}