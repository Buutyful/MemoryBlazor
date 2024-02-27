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
    private ImmutableList<int> MemoryValues => 
        Constants.GetMemoryValues(BoardSize).ToList().Shuffle();
    private ImmutableList<Cell> GameBoard {  get; }
    private Board(Difficulty difficulty)
    {
        _difficulty = difficulty;
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
