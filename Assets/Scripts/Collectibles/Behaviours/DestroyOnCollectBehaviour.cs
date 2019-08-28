using Collectibles.Interfaces;

namespace Collectibles.Behaviours
{
    public class DestroyOnCollectBehaviour : CollectibleBehaviour
    {
        protected override void OnGetCollectedBy(ICollector collector)
        {
            Destroy(gameObject);
        }
    }
}