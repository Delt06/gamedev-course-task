using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(ShootingEnemyController))]
    public class ShootingEnemyAnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private ShootingEnemyController _shootingEnemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _shootingEnemy = GetComponent<ShootingEnemyController>();

            _shootingEnemy.ShootingStarted += (sender, args) =>
            {
                _animator.Play(ShootState); 
                _animator.SetFloat(AttackSpeed, 1f / args.AttackTime);                
            };

            _shootingEnemy.ShootingEnded += (sender, args) => _animator.Play(IdleState);
        }

        private static readonly int AttackSpeed = Animator.StringToHash("AttackSpeed");
        
        private static readonly int IdleState = Animator.StringToHash("Idle");
        private static readonly int ShootState = Animator.StringToHash("Shoot");
    }
}