using Memory.Library;
using Microsoft.AspNetCore.Components;

namespace MemoryBlazor.Components;

public abstract class CardComponentBase : ComponentBase, IDisposable
{
    [Parameter] public GameCard GameCard { get; set; }  

    public void Dispose()
    {
        
    }
}

