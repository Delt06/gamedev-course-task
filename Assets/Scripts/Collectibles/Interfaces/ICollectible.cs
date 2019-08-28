using JetBrains.Annotations;

namespace Collectibles.Interfaces
{
    public interface ICollectible
    {
        void GetCollectedBy([NotNull] ICollector collector);
    }
}