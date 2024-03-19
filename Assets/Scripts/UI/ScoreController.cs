using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreController : MonoBehaviour
    {
        private const string BEST_SCORE = "BestScore";

        public int CurrentScore => _currentScore;

        [SerializeField] private TextMeshProUGUI _currentScoreLabel;
        [SerializeField] private AudioSource _bestScoreSound;
        [SerializeField] private int _scorePerSquare;
        [SerializeField] private float _scaleDuration;
        [SerializeField] private float _scaleFactor;

        private int _currentScore;
        private int _bestScore;

        private void Awake()
        {
            _bestScore = PlayerPrefs.GetInt(BEST_SCORE);
        }

        public void AddScore()
        {
            _currentScore += _scorePerSquare;

            _currentScoreLabel.text = _currentScore.ToString();
            _currentScoreLabel.transform
                .DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 0)
                .OnComplete(() => _currentScoreLabel.transform.DOScale(Vector3.one, 0)); 
        }

        public int GetBestScore()
        {
            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;

                PlayerPrefs.SetInt(BEST_SCORE, _bestScore);
                PlayerPrefs.Save();
                _bestScoreSound.Play();
            }

            return _bestScore;
        }
    }
}