using System;
using Collectibles.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Collectibles.Behaviours
{
    public abstract class CollectibleBehaviour : MonoBehaviour, ICollectible
    {
        public void GetCollectedBy(ICollector collector)
        {
            if (collector is null) throw new ArgumentNullException(nameof(collector));

            OnGetCollectedBy(collector);
        }

        protected abstract void OnGetCollectedBy([NotNull] ICollector collector);
    }
}