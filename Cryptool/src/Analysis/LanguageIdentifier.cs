namespace Diefesson.Cryptool.Analysis;

public record AnalysisEntry
{
    public string Language
    { get; private set; }
    public int Score
    { get; private set; }

    internal AnalysisEntry(string language, int score)
    {
        Language = language;
        Score = score;
    }
}

public class LanguageIdentifier
{
    private readonly TrigramList[] trigamLists;

    public LanguageIdentifier(params TrigramList[] trigamLists)
    {
        this.trigamLists = trigamLists;
    }

    public AnalysisEntry[] Analyze(string text)
    {
        text = text.ToUpper();
        var analisys = trigamLists.ToDictionary(tl => tl.language, _ => 0);
        for (var t = 0; t < text.Length - 2; t++)
        {
            var trigram = String.Concat(text.Skip(t).Take(3));
            foreach (var tl in trigamLists)
            {
                if (tl.Contains(trigram))
                {
                    analisys[tl.language]++;
                }
            }
        }
        return analisys.Select(e => new AnalysisEntry(e.Key, e.Value)).ToArray();
    }

    public AnalysisEntry InferLanguage(string text)
    {
        var analisys = Analyze(text);
        return analisys.MaxBy(e => e.Score)!;
    }

}