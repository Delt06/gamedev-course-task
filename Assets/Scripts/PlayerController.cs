using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour, IPlayer
{
    #pragma warning disable 0649
    
    [SerializeField, Range(0.01f, 1000f)] private float _moveSpeed = 5f;
    [SerializeField, Range(0.01f, 1000f)] private float _jumpPower = 10f;
    [SerializeField] private JumpController _jumpController;
    
    #pragma warning restore 0649

    public float MoveSpeed => _moveSpeed;

    private bool _alive = true;
    
    public bool Alive
    {
        get => _alive;
        set
        {
            if (!_alive) return;

            _alive = value;
            if (_alive) return;

            SetVelocityX(0f, 0f);
            
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Death?.Invoke(this, EventArgs.Empty);
    }

    public InputData InputData { get; set; }
    public event EventHandler Moving;
    public event EventHandler Idling;
    public event EventHandler Death;
    public event EventHandler Fall;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!Alive) return;
        
        var falling = !_jumpController.IsGrounded;
        var moving = !Mathf.Approximately(InputData.HorizontalMovement, 0f);
        
        SetVelocityX(_moveSpeed, InputData.HorizontalMovement);
        
        if (falling)
        {
            OnFall();
        } 
        else if (moving)
        {
            OnMove();
        }
        else
        {
            OnIdle();
        }
        
        if (InputData.Jump && _jumpController.CanJump)
        {
            Jump(_jumpPower);
        }
    }

    private void OnMove()
    {
        Moving?.Invoke(this, EventArgs.Empty);
    }

    private void OnFall()
    {
        Fall?.Invoke(this, EventArgs.Empty);
    }

    private void OnIdle()
    {
        Idling?.Invoke(this, EventArgs.Empty);
    }

    private void SetVelocityX(float moveSpeed, float input)
    {
        var velocity = _rigidbody.velocity;
        velocity.x = _moveSpeed * input;
        _rigidbody.velocity = velocity;

        if (!Mathf.Approximately(velocity.x, 0f))
        {
            _spriteRenderer.flipX = velocity.x < 0f;    
        }
    }

    private void Jump(float jumpPower)
    {
        _rigidbody.AddForce(_jumpPower * Vector2.up, ForceMode2D.Impulse);
        _jumpController.OnJump();
    }
}
