using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Memory.Library;

public class Board
{
    private readonly Difficulty _difficulty;  
    private ImmutableList<int> MemoryValues { get; }
    private ImmutableList<Card> GameBoard { get; }
    public IEnumerable<Card> GetGameBoard => GameBoard;
    public int BoardSize =>
        Constants.GetBoardSize(_difficulty);
    public Card this[int index]
    {
        get => index < GameBoard.Count ?
            GameBoard[index] : throw new ArgumentException("Index out fo board range");
    }
    private Board(Difficulty difficulty)
    {
        _difficulty = difficulty;
        MemoryValues = Constants.GetMemoryValues(BoardSize).ToList().Shuffle();
        GameBoard = [.. GenerateBoard()];
    }
    public static Board Initialize(Difficulty difficulty) => new(difficulty);

    private IEnumerable<Card> GenerateBoard() =>
        Enumerable.Range(0, BoardSize)
        .Select(i => new Card(MemoryValues[i]));
}
