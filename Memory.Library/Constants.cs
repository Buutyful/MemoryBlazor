namespace Memory.Library;

public static class Constants
{
    private static readonly int _baseBoardDimention = 4;
    public static int GetBoardDimention(Difficulty difficulty) =>
       _baseBoardDimention * (int)difficulty;
    public static int GetBoardSize(Difficulty difficulty) =>
        (int)Math.Pow(GetBoardDimention(difficulty), 2);
    public static IEnumerable<int> GetMemoryValues(int size)
    {
        for (int i = 0; i < size / 2; i++)
        {
            yield return i;
            yield return i;
        }
    }
}
public enum Difficulty
{
    Easy = 1,
    Medium = 2,
    Impossible = 3
}