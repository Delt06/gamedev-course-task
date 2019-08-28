using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileController : MonoBehaviour
    {
        #pragma warning disable 0649
        
        [SerializeField] private KillController _killController;
        [SerializeField] private string _groundLayerName = "Ground";
        [SerializeField] private string _solidLayerName = "Solid";
        
        #pragma warning restore 0649

        private LayerMask _layerMask;
        public float LifeTime = 2f;

        private float _destroyTime;
        
        private void Start()
        {
            _destroyTime = Time.time + LifeTime;
            
            _layerMask = LayerMask.GetMask(_groundLayerName, _solidLayerName);

            _killController.HitPlayer += (sender, player) => Disappear();
        }

        private void Update()
        {
            if (Time.time >= _destroyTime)
            {
                Disappear();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((1 << other.gameObject.layer & _layerMask) == 0) return;
            
            Disappear();
        }

        private void Disappear() => Destroy(gameObject);
    }
}
