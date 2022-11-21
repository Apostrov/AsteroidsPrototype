using UnityEngine;

namespace Asteroids.Player.Laser
{
    public class LaserVisualComponent : MonoBehaviour
    {
        [SerializeField] private Transform Player;
        [SerializeField] private LineRenderer Laser;

        private float _showTime;

        private void Update()
        {
            if (_showTime > 0f)
            {
                _showTime -= Time.deltaTime;
                if (_showTime < 0f)
                {
                    Laser.gameObject.SetActive(false);
                }
            }
        }

        public void SetShootPoint(Vector3 position, float showTime)
        {
            var player = Player.position;
            Laser.SetPosition(0, player);
            Laser.SetPosition(1, player + position);
            Laser.gameObject.SetActive(true);
            _showTime = showTime;
        }
    }
}