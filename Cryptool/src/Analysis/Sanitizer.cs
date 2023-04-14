namespace Diefesson.Cryptool.Analysis;

using System.Text;

public record SanitizerOptions
{
    public bool convert { get; set; } = true;

    public bool spaces { get; set; } = true;

    public bool lines { get; set; } = true;

    public bool upper { get; set; } = true;
}


public static class Sanitizer
{
    private static Func<char, bool> createFilter(SanitizerOptions options)
    {
        return (c) => Char.IsAsciiLetter(c) | (c == ' ' & options.spaces) | (c == '\n' & options.lines);
    }

    public static string Sanitize(string text, SanitizerOptions options)
    {
        var filter = createFilter(options);
        if (options.convert)
        {
            text = text.Normalize(NormalizationForm.FormD);
        }
        var cleaned = text.Where(filter);
        if (options.upper)
        {
            cleaned = cleaned.Select(Char.ToUpper);
        }
        return String.Concat(cleaned);
    }
}
