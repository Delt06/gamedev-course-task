using JetBrains.Annotations;

namespace Collectibles.Interfaces
{
    public interface IDoor
    {
        bool TryOpen([NotNull] IKey key);

        bool CanBeOpenedWith([NotNull] IKey key);
        
        bool IsOpen { get; }
    }
}