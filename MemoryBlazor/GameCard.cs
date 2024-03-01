using Memory.Library;
using Microsoft.AspNetCore.Components;

namespace MemoryBlazor;

public class GameCard(Card card)
{
    public Card Card { get; set; } = card;
    public bool Reveald { get; set; } = false;
    public bool Hidden { get; set; } = false;
}
