using System;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Collider2D))]
    public class KillController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var player = other.GetComponent<IPlayer>();
            if (player == null || !player.Alive) return;

            player.Alive = false;
            HitPlayer?.Invoke(this, player);
        }

        public event EventHandler<IPlayer> HitPlayer;
    }
}