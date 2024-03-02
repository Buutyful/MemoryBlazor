namespace Memory.Library;

public class Game
{
    private readonly Timer _timer;
    public Board Board { get; }
    public GameState State { get; private set; } = GameState.Going;
    public int CountDown { get; private set; }
    public int MovesCount { get; private set; }
    public List<Card> CorrectCards { get; private set; } = [];
    public Result? Result { get; private set; }
    public event EventHandler<int> TimerElapsed;
    private Game(Difficulty difficulty)
    {
        Board = Board.Initialize(difficulty);
        CountDown = 120 * (int)difficulty;
        _timer = new Timer(OnTimerElapsed, null, 1000, 1000);
    }
    public static Game Initialize(Difficulty difficulty)
    {
        return new Game(difficulty);
    }
    public bool MakeMove(Card card1, Card card2)
    {
        MovesCount++;
        if (card1 != card2 && card1.SameValue(card2))
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
            Result = Result.Lost(EndReason.TimeOut, this);

        }

        TimerElapsed.Invoke(this, CountDown);

    }
    public void UnsubscribeFromTimerElapsed()
    {
        _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        _timer?.Dispose();
    }

    private void CheckGameOver()
    {
        if (Board.BoardSize == CorrectCards.Count)
        {
            UnsubscribeFromTimerElapsed();
            State = GameState.Over;
        }
        Result = Result.Win(this);
    }

}
public record Result
{
    public EndReason EndReason { get; }
    public Game Game { get; }
    private Result(EndReason reason, Game game) =>
        (EndReason, Game) = (reason, game);
    public static Result Win(Game game)
        => new(EndReason.Win, game);
    public static Result Lost(EndReason reason, Game game)
        => new(reason, game);
    public string DisplayResult() =>
        $"{EndReason},\n" +
        $"Total moves: {Game.MovesCount},\n" +
        $"Time Left: {Game.CountDown},\n" +
        $"Total Cards: {Game.CorrectCards.Count}";
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