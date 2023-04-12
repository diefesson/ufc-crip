namespace Diefesson.Cryptool.Analisys;

using System.Collections;

public class TrigramList : IEnumerable<string>
{
    public static readonly TrigramList ENUS = new TrigramList(
    Languages.ENUS,
    new string[]
    {
            "the",
            "and",
            "tha",
            "ent",
            "ing",
            "ion",
            "tio",
            "for",
            "nde",
            "has",
            "nce",
            "edt",
            "tis",
            "oft",
            "sth",
            "men",
    }
);
    public static readonly TrigramList PTBR = new TrigramList(
        Languages.PTBR,
        new string[]{
            "que",
            "ent",
            "com",
            "nte",
            "est",
            "ava",
            "ndo",
            "ado",
            "ara",
            "par",
            "and",
            "men",
            "uma",
            "con",
            "ada",
            "res",
            "inh",
            "ant",
            "des"
        }
    );

    public readonly string language;
    public int Length
    {
        get { return trigrams.Length; }
    }
    private readonly string[] trigrams;

    public TrigramList(string language, string[] trigrams)
    {
        this.language = language;
        this.trigrams = trigrams;
    }

    public string this[int index]
    {
        get { return trigrams[index]; }
    }

    public IEnumerator<string> GetEnumerator()
    {
        return ((IEnumerable<string>)trigrams).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return trigrams.GetEnumerator();
    }
}