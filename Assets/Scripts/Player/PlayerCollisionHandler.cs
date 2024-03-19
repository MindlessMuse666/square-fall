using Game;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent _playerDied;
        [SerializeField] private UnityEvent _squareCollected;

        [SerializeField] private float _scaleChangeDuration;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag(GlobalConstants.ALLY_TAG))
            {
                collider.enabled = false;

                collider.transform
                    .DOScale(Vector3.zero, _scaleChangeDuration)
                    .OnComplete(() => 
                    {
                        _squareCollected?.Invoke();
                        Destroy(collider.gameObject);
                    });
            }
            
            if (collider.CompareTag(GlobalConstants.ENEMY_TAG))
            {
                _playerDied?.Invoke();

                Destroy(collider.gameObject);
            }
        }
    }
}