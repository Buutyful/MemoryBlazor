using System.Collections.Generic;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Memory.Library;

public class Board
{
    private readonly Difficulty _difficulty;
    private int BoardDimention =>
        Constants.GetBoardDimention(_difficulty);
    private int BoardSize =>
        Constants.GetBoardSize(_difficulty);
    private ImmutableList<int> MemoryValues { get; }
    private ImmutableList<Cell> GameBoard { get; }
    public IEnumerable<Cell> GetGameBoard => GameBoard;
    public Cell this[int index]
    {
        get => index < GameBoard.Count ?
            GameBoard[index] : throw new ArgumentException("Index out fo board range");
    }
    private Board(Difficulty difficulty)
    {
        _difficulty = difficulty;
        MemoryValues = Constants.GetMemoryValues(BoardSize).Shuffle();
        GameBoard = [.. GenerateBoard()];
    }
    public static Board Initialize(Difficulty difficulty) => new(difficulty);

    private IEnumerable<Cell> GenerateBoard() =>
        Enumerable.Range(0, BoardSize)
        .Select(i => new Cell(
            i / BoardDimention,
            i % BoardDimention,
            MemoryValues[i]));
}
