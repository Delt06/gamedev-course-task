using System;
using System.Linq;
using Collectibles.Interfaces;
using JetBrains.Annotations;

namespace Collectibles.Extensions
{
    public static partial class CollectorExtensions
    {
        public static int GetTotalCoinsValue([NotNull] this ICollector collector)
        {
            if (collector is null) throw new ArgumentNullException(nameof(collector));

            return collector.Collectibles
                .OfType<ICoin>()
                .Select(c => c.Value)
                .Sum();
        }
    }
}