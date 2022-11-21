using Asteroids.Player.Move;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Player.Stats
{
    public class PlayerStatsUI : MonoBehaviour, IPlayerStatsVisitor
    {
        [SerializeField] private TMP_Text _position;
        [SerializeField] private TMP_Text _rotation;
        [SerializeField] private TMP_Text _speed;
        [SerializeField] private Image _laserReload;

        public void UpdatePlayerMoveInfo(IInputMovable player)
        {
            _position.text = $"Position: {player.GetPosition()}";
            _rotation.text = $"Rotation: {player.GetRotation().eulerAngles}";
        }

        public void UpdatePlayerSpeed(float speed)
        {
            _speed.text = $"Speed: {speed}";
        }

        public void UpdateLaserInfo(float reloadPercent)
        {
            _laserReload.fillAmount = reloadPercent;
        }
    }
}