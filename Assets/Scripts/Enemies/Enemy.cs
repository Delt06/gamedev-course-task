using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        protected virtual void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        protected SpriteRenderer SpriteRenderer { get; private set; }
    }
}