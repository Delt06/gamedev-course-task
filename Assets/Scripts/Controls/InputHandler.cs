using UnityEngine;

namespace Controls
{
    [RequireComponent(typeof(IPlayer))]
    public class InputHandler : MonoBehaviour
    {
        private IPlayer _player;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            
            if (_player == null)
            {
                Debug.LogWarning($"{nameof(InputHandler)} was not able to find a player.");
            }
        }

        private void Update()
        {
            if (_player == null) return;

            _player.InputData = ReadInput();
        }

        private static InputData ReadInput()
        {
            var horizontalMovement = Input.GetAxisRaw("Horizontal");
            var jump = Input.GetButtonDown("Jump");
            
            return new InputData(horizontalMovement, jump);
        }
    }
}