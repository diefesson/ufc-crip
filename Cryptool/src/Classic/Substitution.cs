using System.Text;
using Diefesson.Cryptool.Analysis;

namespace Diefesson.Cryptool.Classic;

public static class Substitution
{

    public static string Encrypt(string ciphertext, string key)
    {
        var plaintext = new StringBuilder(ciphertext.Length);
        foreach (var c in ciphertext)
        {
            if (Char.IsAsciiLetter(c))
            {
                var i = ClassicMath.C2I(c);
                var p = key[i];
                if (Char.IsLower(c))
                    p = Char.ToLower(p);
                plaintext.Append(p);
            }
            else
            {
                plaintext.Append(c);
            }
        }
        return plaintext.ToString();
    }

    public static string Decrypt(string plaintext, string key)
    {
        var ciphertext = new StringBuilder(plaintext.Length);
        foreach (var p in plaintext)
        {
            if (Char.IsAsciiLetter(p))
            {
                var i = key.IndexOf(Char.ToUpper(p)) % key.Length;
                var c = ClassicMath.I2C(i, Char.IsLower(p));
                ciphertext.Append(c);
            }
            else
            {
                ciphertext.Append(p);
            }
        }
        return ciphertext.ToString();
    }

    public static string ParseKey(string keyText)
    {
        var key = new StringBuilder(ClassicMath.Alphabet.Count);
        var sanitizerOptions = new SanitizerOptions
        {
            Spaces = false,
            Lines = false,
            Punctuation = false,
        };
        var sanitized = Sanitizer.Sanitize(keyText, sanitizerOptions);
        key.Append(String.Concat(sanitized.Distinct()));
        foreach (var l in ClassicMath.Alphabet)
        {
            if (!sanitized.Contains(l))
                key.Append(l);
        }
        return key.ToString();
    }
}
