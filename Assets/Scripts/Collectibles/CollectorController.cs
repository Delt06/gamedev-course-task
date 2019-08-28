using System;
using System.Collections.Generic;
using Collectibles.Interfaces;
using UnityEngine;

namespace Collectibles
{
    public class CollectorController : MonoBehaviour, ICollector
    {
        private void Awake()
        {
            _collectibles = new HashSet<ICollectible>();
        }

        public IEnumerable<ICollectible> Collectibles => _collectibles;

        private ISet<ICollectible> _collectibles;
        
        public void Collect(ICollectible collectible)
        {
            if (collectible is null) throw new ArgumentNullException(nameof(collectible));
            
            collectible.GetCollectedBy(this);
            _collectibles.Add(collectible);
            Collected?.Invoke(this, collectible);
        }

        public event EventHandler<ICollectible> Collected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var collectible = other.GetComponent<ICollectible>();
            if (collectible == null) return;
            
            Collect(collectible);
        }
    }
}