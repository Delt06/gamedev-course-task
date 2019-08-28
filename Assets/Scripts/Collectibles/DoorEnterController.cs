using Collectibles.Interfaces;
using UnityEngine;

namespace Collectibles
{
    public class DoorEnterController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var door = other.GetComponent<IDoor>();
            if (door == null || !door.IsOpen) return;
            
            gameObject.SetActive(false);
        }
    }
}