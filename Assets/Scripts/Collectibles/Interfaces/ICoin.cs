namespace Collectibles.Interfaces
{
    public interface ICoin : ICollectible
    {
        int Value { get; }
    }
}