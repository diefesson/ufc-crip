namespace Diefesson.Cryptool.Analysis;

public record FreqDistEntry<K>(K Key, int Count, float Freq) where K : notnull;

public class FreqDist<K> where K : notnull
{
    private readonly Dictionary<K, int> counts;
    private int total;

    public FreqDist()
    {
        counts = new Dictionary<K, int>();
        total = 0;
    }

    public int GetCount(K key)
    {
        if (counts.ContainsKey(key))
            return counts[key];
        return 0;
    }

    public float GetFreq(K key)
    {
        if (total == 0)
            return 0.0f;
        else
            return GetCount(key) / total;
    }

    public void Count(K key, int number)
    {
        counts[key] = GetCount(key) + number;
        total += number;
    }

    public IEnumerable<FreqDistEntry<K>> Tops()
    {
        return counts
            .Select((kp) => new FreqDistEntry<K>(kp.Key, kp.Value, (float)kp.Value / total * 100))
            .OrderByDescending(e => e.Count);
    }

}