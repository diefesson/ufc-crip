namespace Diefesson.Cryptool.Analisys;

using System.Collections;

public class TrigramList : IEnumerable<string>
{
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