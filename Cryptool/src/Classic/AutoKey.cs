namespace Diefesson.Cryptool.Classic;

using System.Text;

public static class AutoKey
{

    public static string Encrypt(string plaintext, string key)
    {
        var ciphertext = new StringBuilder(plaintext.Length);
        var keystream = new StringBuilder(key, plaintext.Length);
        var ki = 0;
        foreach (var p in plaintext)
        {
            if (Char.IsAsciiLetter(p))
            {
                var k = keystream[ki];
                var shift = ClassicMath.C2I(k);
                char c = ClassicMath.Rot(p, shift);
                ciphertext.Append(c);
                keystream.Append(p);
                ki++;
            }
            else
            {
                ciphertext.Append(p);
            }
        }
        return ciphertext.ToString();
    }

    public static string Decrypt(string ciphertext, string key)
    {
        var plaintext = new StringBuilder(ciphertext.Length);
        var keystream = new StringBuilder(key, ciphertext.Length);
        var ki = 0;
        foreach (var c in ciphertext)
        {
            if (Char.IsAsciiLetter(c))
            {
                var k = keystream[ki];
                var shift = ClassicMath.C2I(k);
                char p = ClassicMath.Rot(c, -shift);
                plaintext.Append(p);
                keystream.Append(p);
                ki++;
            }
            else
            {
                plaintext.Append(c);
            }
        }
        return plaintext.ToString();
    }

}