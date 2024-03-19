using UnityEngine;
using DG.Tweening;

namespace Square
{
    public class SquareDestructionTrigger : MonoBehaviour
    {
        [SerializeField] private float _scaleChangeDuration;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            collider.enabled = false;
            collider.gameObject.transform
                .DOScale(Vector3.zero, _scaleChangeDuration)
                .OnComplete(() => Destroy(collider.gameObject));
        }
    }
}