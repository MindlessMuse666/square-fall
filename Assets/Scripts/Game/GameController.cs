using Square;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private SquareSpawner _squareSpawner;
        [SerializeField] private GameObject _gameStartScreen;
        [SerializeField] private GameObject _gameScreen;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private float _gameOverScreenShowDelay;

        private bool _wasGameOver;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(false);
            _gameStartScreen.SetActive(true);
        }

        private void Update()
        {
            if (_wasGameOver)
            {
                _gameOverScreenShowDelay -= Time.deltaTime;
                
                if (_gameOverScreenShowDelay <= 0)
                {
                    ShowGameOverScreen();
                }
            }
        }

        public void RestartGame()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(sceneName);
        }

        public void StartGame()
        {
            _gameStartScreen.SetActive(false);
            _gameScreen.SetActive(true);
        }

        public void OnPlayerDied()
        {
            _wasGameOver = true;
            _squareSpawner.enabled = false;
        }

        private void ShowGameOverScreen()
        {
            _gameScreen.SetActive(false);
            _gameOverScreen.SetActive(true);
        }
    }
}