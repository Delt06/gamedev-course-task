using System;
using Collectibles.Interfaces;
using UnityEngine;

namespace Collectibles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Door : MonoBehaviour, IDoor
    {
        #pragma warning disable 0649
        
        [SerializeField] private Key _key;
        [SerializeField] private Sprite _openSprite;
        
        #pragma warning restore 0649

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool IsOpen { get; private set; }
        
        public bool TryOpen(IKey key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));
            
            if (!CanBeOpenedWith(key)) return false;
            
            Open();
            
            return true;
        }

        public bool CanBeOpenedWith(IKey key)
        {
            return key == (IKey) _key;
        }

        private void Open()
        {
            _spriteRenderer.sprite = _openSprite;
            IsOpen = true;
        }
    }
}