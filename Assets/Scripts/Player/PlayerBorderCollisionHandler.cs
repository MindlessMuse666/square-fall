using Game;
using UnityEngine;

namespace Player
{
    public class PlayerBorderCollisionHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource _reboundSound;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _reboundSound.Play();
            }
        }
    }
}