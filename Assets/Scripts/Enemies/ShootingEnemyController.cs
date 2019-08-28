using System;
using System.Collections;
using Enemies.Args;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class ShootingEnemyController : MonoBehaviour
    {
        #pragma warning disable 0649
        
        [SerializeField] private ProjectileController _projectilePrefab;
        [SerializeField, Range(0.01f, 10f)] private float _minShootTime = 0.5f;
        [SerializeField, Range(0.01f, 10f)] private float _maxShootTime = 2f;
        [SerializeField, Range(0.01f, 10f)] private float _attackTime = 1f;
        [SerializeField] private Vector2 _shootingPoint;
        [SerializeField, Range(0.01f, 100f)] private float _projectileSpeed = 5f;
        
        #pragma warning restore 0649

        private IEnumerator _shootingCoroutine;
        private float _nextAttackTime;

        private void Awake()
        {
            if (_maxShootTime < _minShootTime)
            {
                _maxShootTime = _minShootTime;
            }
            
            ScheduleShot();

            ShootingEnded += (sender, args) => _shootingCoroutine = null;
        }

        private void ScheduleShot()
        {
            _nextAttackTime = Time.time + Random.Range(_minShootTime, _maxShootTime);
        }

        private void Update()
        {
            if (_shootingCoroutine == null && Time.time >= _nextAttackTime)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (_shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
            }

            _shootingCoroutine = ShootingCoroutine();
            StartCoroutine(_shootingCoroutine);
        }

        private IEnumerator ShootingCoroutine()
        {
            ShootingStarted?.Invoke(this, new AttackTimeArgs(_attackTime));
            
            yield return new WaitForSeconds(_attackTime);
            
            CreateProjectile();

            ScheduleShot();
            ShootingEnded?.Invoke(this, EventArgs.Empty);
        }

        private void CreateProjectile()
        {
            var projectile = Instantiate(_projectilePrefab, ProjectileSpawnPoint, Quaternion.identity);
            var body = projectile.GetComponent<Rigidbody2D>();
            var direction = Mathf.Sign(transform.localScale.x);
            body.velocity = direction * _projectileSpeed * Vector2.right;
        }

        public event EventHandler<AttackTimeArgs> ShootingStarted;
        public event EventHandler ShootingEnded;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(ProjectileSpawnPoint, 0.1f);
        }

        private Vector3 ProjectileSpawnPoint => transform.position + (Vector3) _shootingPoint;
    }
}