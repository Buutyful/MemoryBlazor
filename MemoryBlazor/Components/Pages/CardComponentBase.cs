using Memory.Library;
using Microsoft.AspNetCore.Components;

namespace MemoryBlazor.Components;

public abstract class CardComponentBase : ComponentBase
{
    [Parameter] public Card Card { get; set; }
    public bool Reveald { get; set; } = false;
    public bool Hidden { get; set; } = false;
}

