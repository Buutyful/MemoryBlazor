namespace Memory.Library;

public class Cell(int row, int col, int value) : IEquatable<Cell>
{
    public int X { get; } = row;
    public int Y { get; } = col;    
    public int Value { get; } = value;

    public override bool Equals(object? obj) =>
        obj is Cell cell && Equals(cell);
    public bool Equals(Cell? other) =>
       this is null ? other is null :
       Value == other?.Value;
    public static bool operator ==(Cell? a, Cell? b) => a is null ? b is null : a.Equals(b);
    public static bool operator !=(Cell? a, Cell? b) => !(a == b);
    public override int GetHashCode() => Value.GetHashCode();
   
}
