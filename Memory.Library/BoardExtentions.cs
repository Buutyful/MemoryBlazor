using System.Collections.Immutable;

namespace Memory.Library;

public static class BoardExtentions
{
    private static readonly Random random = new();
    public static ImmutableList<int> Shuffle(this List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]); 
        }
        return [.. list];
    }
}