namespace Diefesson.Cryptool.Analisys;

public class LanguageIdentifier
{
    private readonly TrigramList[] trigamLists;

    public LanguageIdentifier(params TrigramList[] trigamLists)
    {
        this.trigamLists = trigamLists;
    }

    public Dictionary<string, int> Analyze(string text)
    {
        var scores = trigamLists.ToDictionary(tl => tl.language, _ => 0);
        for (var t = 0; t < text.Length - 2; t++)
        {
            var trigram = String.Concat(text.Skip(t).Take(3));
            foreach (var tl in trigamLists)
            {
                if (tl.Contains(trigram))
                {
                    scores[tl.language]++;
                }
            }
        }
        return scores;
    }

    public string InferLanguage(string text)
    {
        var scores = Analyze(text);
        return scores.MaxBy(kp => kp.Value).Key;
    }

}