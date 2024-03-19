using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;

        [SerializeField] private float _speed;

        private bool _isMovingRight;
        private float _oneWayTime;
        private float _currentTime;

        private void Awake()
        {
            _oneWayTime = Vector3.Distance(_leftBorder.position, _rightBorder.position) / _speed;
            _currentTime = Vector3.Distance(_leftBorder.position, transform.position) / _speed;
        }

        private void Update()
        {
            Move();
        }

        public void ChangeDirection()
        {
            _isMovingRight = !_isMovingRight;
        }

        private void Move()
        {
            _currentTime += _isMovingRight ? Time.deltaTime : -Time.deltaTime;

            var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
            transform.position = Vector3.Lerp(_leftBorder.position, _rightBorder.position, progress);
        }        
    }
}