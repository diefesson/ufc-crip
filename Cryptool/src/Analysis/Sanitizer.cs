namespace Diefesson.Cryptool.Analysis;

using System.Text;

public record SanitizerOptions
{
    public bool Convert { get; set; } = true;

    public bool Spaces { get; set; } = true;

    public bool Lines { get; set; } = true;

    public bool Punctuation { get; set; } = true;

    public bool Upper { get; set; } = true;
}


public static class Sanitizer
{
    private static Func<char, bool> createFilter(SanitizerOptions options)
    {
        return (c) => (
            Char.IsAsciiLetter(c) ||
            c == ' ' && options.Spaces ||
            c == '\n' && options.Lines ||
            Char.IsPunctuation(c) && options.Punctuation
        );
    }

    public static string Sanitize(string text, SanitizerOptions options)
    {
        var filter = createFilter(options);
        if (options.Convert)
        {
            text = text.Normalize(NormalizationForm.FormD);
        }
        var cleaned = text.Where(filter);
        if (options.Upper)
        {
            cleaned = cleaned.Select(Char.ToUpper);
        }
        return String.Concat(cleaned);
    }
}
