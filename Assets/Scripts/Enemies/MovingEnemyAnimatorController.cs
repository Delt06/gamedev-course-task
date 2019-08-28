using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Animator), typeof(MovingEnemy))]
    public class MovingEnemyAnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private MovingEnemy _enemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<MovingEnemy>();
        }

        private void Update()
        {
            _animator.SetFloat(MoveSpeedProperty, _enemy.MoveSpeed);
        }

        private static readonly int MoveSpeedProperty = Animator.StringToHash("MoveSpeed");
    }
}