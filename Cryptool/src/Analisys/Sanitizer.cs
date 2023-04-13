namespace Diefesson.Cryptool.Analisys;

using System.Text;
using System.Globalization;

public static class Sanitizer
{
    public static string Sanitize(string text)
    {
        var cleaned = text
            .Normalize(NormalizationForm.FormD)
            .Where(Char.IsAsciiLetter)
            .Select(Char.ToUpper);
        return String.Concat(cleaned);
    }
}