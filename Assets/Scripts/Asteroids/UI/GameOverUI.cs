using Asteroid.Points;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class GameOverUI : MonoBehaviour, IPointsCounter
    {
        [SerializeField] private TMP_Text Score;
        [SerializeField] private Button RestartButton;

        private int _points = 0;

        private void Awake()
        {
            RestartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }

        public void AddPoints(int points)
        {
            _points += points;
            Score.text = $"Score: {_points}";
        }
    }
}