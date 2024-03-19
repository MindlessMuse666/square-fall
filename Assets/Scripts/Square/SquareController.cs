using UnityEngine;

namespace Square
{
    public class SquareController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationPower;

        private Rigidbody2D _rigidbody;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rotationPower *= GetRandomSign();
        }

        private void FixedUpdate()
        {
            _rigidbody.rotation += _rotationPower;
            _rigidbody.velocity = _direction * _speed;
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private int GetRandomSign()
        {
            var randomNumber = Random.Range(0, 2);

            return randomNumber == 1? 1 : -1;
        }
    }
}