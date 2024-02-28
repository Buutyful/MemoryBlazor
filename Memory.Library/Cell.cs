namespace Memory.Library;

public readonly struct Card(int value) : IEquatable<Card>
{   
    public int MemoryValue { get; } = value;

    public override bool Equals(object? obj) =>
        obj is Card cell && Equals(cell);
    public bool Equals(Card other) =>
       MemoryValue == other.MemoryValue;
    public static bool operator ==(Card? a, Card? b) => a is null ? b is null : a.Equals(b);
    public static bool operator !=(Card? a, Card? b) => !(a == b);
    public override int GetHashCode() => MemoryValue.GetHashCode();

}
