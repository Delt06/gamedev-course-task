using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovingEnemy : Enemy
    {
        [SerializeField, Range(0.01f, 1000f)] private float _moveSpeed = 5f;
        [SerializeField, Range(0.01f, 1000f)] private float _movementAreaWidth = 5f;

        public float MoveSpeed => _moveSpeed;
        
        private Rigidbody2D _rigidbody;
        private Vector3 _startPosition;
        private bool _right;

        protected override void Awake()
        {
            base.Awake();
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _right = Random.value >= 0.5f;

            _startPosition = transform.position;
        }

        private void Move(bool right)
        {
            var velocity = _rigidbody.velocity;
            velocity.x = (right ? 1 : -1) * _moveSpeed;
            _rigidbody.velocity = velocity;

            SpriteRenderer.flipX = !right;
        }

        private void FixedUpdate()
        {
            var currentX = transform.position.x;
            var leftX = LeftEnd.x;
            var rightX = RightEnd.x;
            
            if (currentX <= leftX)
            {
                _right = true;
                Move(true);
            } 
            else if (currentX >= rightX)
            {
                _right = false;
            }
            
            Move(_right);
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
            {
                _startPosition = transform.position;
            }
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(LeftEnd, RightEnd);
        }

        private Vector3 LeftEnd => _startPosition + Vector3.left * HalfAreaWidth;
        private Vector3 RightEnd => _startPosition + Vector3.right * HalfAreaWidth;
        private float HalfAreaWidth => _movementAreaWidth * 0.5f;
    }
}