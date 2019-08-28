using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class JumpController : MonoBehaviour
{
    #pragma warning disable 0649
    
    [SerializeField] private LayerMask _groundMask;
    [SerializeField, Range(1, 5)] private int _jumpsCount = 2;
    
    #pragma warning restore 0649    

    public bool CanJump => _jumpsLeft > 0;
    public bool IsGrounded => _colliders.Count > 0;

    private int _jumpsLeft = 0;

    private void Awake()
    {
        var col = GetComponent<Collider2D>();

        if (!col)
        {
            Debug.LogWarning($"{nameof(JumpController)} has no collider attached to it.");
        } 
        else if (!col.isTrigger)
        {
            Debug.LogWarning($"Collider attached to {nameof(JumpController)} must be a trigger.");
        }
        
        _colliders = new HashSet<Collider2D>();
    }

    private ISet<Collider2D> _colliders;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!BelongsToGroundsLevel(other.gameObject)) return;
        
        _colliders.Add(other);

        _jumpsLeft = _jumpsCount;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!BelongsToGroundsLevel(other.gameObject)) return;
        
        if (_colliders.Count > 0)
        {
            _jumpsLeft = _jumpsCount;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!BelongsToGroundsLevel(other.gameObject)) return;
        
        _colliders.Remove(other);
    }

    private bool BelongsToGroundsLevel(GameObject obj)
    {
        return (1 << obj.layer & _groundMask.value) != 0;
    }

    public void OnJump()
    {
        _jumpsLeft--;
    }
}