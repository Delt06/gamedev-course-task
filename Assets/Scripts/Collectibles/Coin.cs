using Collectibles.Behaviours;
using Collectibles.Interfaces;

namespace Collectibles
{
    public class Coin : DestroyOnCollectBehaviour, ICoin
    {
        public int Value = 1;

        int ICoin.Value => Value;
    }
}