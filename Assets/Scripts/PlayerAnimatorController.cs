using UnityEngine;

[RequireComponent(typeof(IPlayer))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private IPlayer _player;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponent<IPlayer>();
        _animator = GetComponent<Animator>();

        _player.Idling += (sender, args) => _animator.Play(IdleState);
        _player.Moving += (sender, args) =>
        {
            _animator.SetFloat(MoveSpeedProperty, _player.MoveSpeed);
            _animator.Play(MoveState);
        };
        _player.Fall += (sender, args) => _animator.Play(FallState);
        _player.Death += (sender, args) => _animator.Play(DeathState);
    }

    private static readonly int MoveSpeedProperty = Animator.StringToHash("MoveSpeed");
    
    private static readonly int IdleState = Animator.StringToHash("Idle");
    private static readonly int MoveState = Animator.StringToHash("Move");
    private static readonly int FallState = Animator.StringToHash("Fall");
    private static readonly int DeathState = Animator.StringToHash("Death");
}