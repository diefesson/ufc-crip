namespace Diefesson.Cryptool.Classic;

using System.Text;

public static class AutoKey
{

    public static string Encrypt(string plaintext, string key)
    {
        var ciphertext = new StringBuilder(plaintext.Length);
        for (var i = 0; i < plaintext.Length; i++)
        {
            var c = plaintext[i];
            if (Char.IsAsciiLetter(c))
            {
                var k = i < key.Length ? key[i] : plaintext[i - key.Length];
                var shift = ClassicMath.C2I(k);
                ciphertext.Append(ClassicMath.Rot(c, shift));
            }
            else
            {
                ciphertext.Append(c);
            }
        }
        return ciphertext.ToString();
    }

    public static string Decrypt(string ciphertext, string key)
    {
        var plaintext = new StringBuilder(ciphertext.Length);
        for (var i = 0; i < ciphertext.Length; i++)
        {
            var c = ciphertext[i];
            if (Char.IsAsciiLetter(c))
            {
                var k = i < key.Length ? key[i] : plaintext[i - key.Length];
                var shift = ClassicMath.C2I(k);
                plaintext.Append(ClassicMath.Rot(c, -shift));
            }
            else
            {
                plaintext.Append(c);
            }
        }
        return plaintext.ToString();
    }

}