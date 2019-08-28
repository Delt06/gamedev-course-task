using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    #pragma warning disable 0649
    
    [SerializeField] private Transform _target;
    [SerializeField] private float _lerp = 10f;
    [SerializeField] private Vector2 _levelSize;
    
    #pragma warning restore 0649

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Follow(_target.position);
    }

    private void Follow(Vector3 position)
    {
        var myPosition = transform.position;
        var newPosition = Vector3.Lerp(myPosition, position, _lerp * Time.deltaTime);
        newPosition.z = myPosition.z;
        transform.position = newPosition;

        ClampPosition();
    }

    private void ClampPosition()
    {
        var position = transform.position;
        var levelHalfSize = _levelSize * 0.5f;
        position.x = Mathf.Clamp(position.x, -levelHalfSize.x + Width * 0.5f, 
            levelHalfSize.x - Width * 0.5f);
        position.y = Mathf.Clamp(position.y, -levelHalfSize.y + Height * 0.5f, 
            levelHalfSize.y - Height * 0.5f);
        transform.position = position;
    }


    private void OnDrawGizmos()
    {
        if (!_camera)
        {
            _camera = GetComponent<Camera>();
        }
        
        var internalBoxSize = new Vector2(_levelSize.x - Width, _levelSize.y - Height);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Vector3.zero, internalBoxSize);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, _levelSize);
    }

    private float Height => _camera.orthographicSize * 2f;
    private float Width => Height * _camera.aspect;
}