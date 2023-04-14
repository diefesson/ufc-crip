namespace Diefesson.Cryptool.Analysis;

using System.Collections;

public class TrigramList : IEnumerable<string>
{
    public static readonly TrigramList ENUS = new TrigramList(
    Languages.ENUS,
    new string[]
    {
            "THE",
            "AND",
            "THA",
            "ENT",
            "ING",
            "ION",
            "TIO",
            "FOR",
            "NDE",
            "HAS",
            "NCE",
            "EDT",
            "TIS",
            "OFT",
            "STH",
            "MEN",
    }
);
    public static readonly TrigramList PTBR = new TrigramList(
        Languages.PTBR,
        new string[]{
            "QUE",
            "ENT",
            "COM",
            "NTE",
            "EST",
            "AVA",
            "NDO",
            "ADO",
            "ARA",
            "PAR",
            "AND",
            "MEN",
            "UMA",
            "CON",
            "ADA",
            "RES",
            "INH",
            "ANT",
            "DES"
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