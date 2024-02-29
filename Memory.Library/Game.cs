namespace Memory.Library;

public class Game
{
    private readonly Timer _timer;
    public Board Board { get; }
    public GameState State { get; private set; }
    public int CountDown { get; private set; }
    public List<Card> CorrectCards { get; private set; } = [];
    public Result? Result { get; private set; }
    private Game(Difficulty difficulty)
    {
        Board = Board.Initialize(difficulty);
        CountDown = 120 * (int)difficulty;
        _timer = new Timer(OnTimerElapsed, null, 1000 * CountDown, 1000);
    }
    public static Game Initialize(Difficulty difficulty) => new(difficulty);
    public bool MakeMove(Card card1, Card card2)
    {
        if (card1 == card2)
        {
            CorrectCards.Add(card1);
            CorrectCards.Add(card2);
            CheckGameOver();
            return true;
        }
        return false;
    }
    private void OnTimerElapsed(object? state)
    {
        CountDown--;
        if (CountDown == 0)
        {
            State = GameState.Over;
            Result = Result.Lost(EndReason.TimeOut);
        }
    }
    private void CheckGameOver()
    {
        if (Board.BoardSize == CorrectCards.Count)
            State = GameState.Over;
        Result = Result.Win();
    }

}
public record Result
{
    public EndReason EndReason { get; }
    private Result(EndReason reason) => EndReason = reason;
    public static Result Win()
        => new(EndReason.Win);
    public static Result Lost(EndReason reason)
        => new(reason);
}
public enum EndReason
{
    Win,
    TimeOut,
    GiveUp
}
public enum GameState
{
    Going,
    Over
}