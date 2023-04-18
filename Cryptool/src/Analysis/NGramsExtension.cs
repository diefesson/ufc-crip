namespace Diefesson.Cryptool.Analysis;

public static class NGramsExtension
{

    public static IEnumerable<string> NGrams(this string str, int size = 1)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException("size");

        for (var i = 0; i < str.Length - size + 1; i++)
        {
            yield return str.Substring(i, size);
        }
    }

}