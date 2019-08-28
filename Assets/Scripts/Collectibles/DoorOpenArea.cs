using System.Linq;
using Collectibles.Interfaces;
using UnityEngine;

namespace Collectibles
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(IDoor))]
    public class DoorOpenArea : MonoBehaviour
    {
        #pragma warning disable 0649
        
        [SerializeField] private Door _door;
        
        #pragma warning restore 0649

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_door.IsOpen) return;
            
            var collector = other.GetComponent<ICollector>();

            var key = collector?.Collectibles
                .OfType<IKey>()
                .FirstOrDefault(k => _door.CanBeOpenedWith(k));

            if (key == null) return;

            _door.TryOpen(key);
        }
    }
}