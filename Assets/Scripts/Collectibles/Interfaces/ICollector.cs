using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Collectibles.Interfaces
{
    public interface ICollector
    {
        IEnumerable<ICollectible> Collectibles { get; }

        void Collect([NotNull] ICollectible collectible);
        
        event EventHandler<ICollectible> Collected;
    }
}