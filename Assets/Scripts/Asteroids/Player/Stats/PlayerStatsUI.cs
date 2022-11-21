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
        [SerializeField] private TMP_Text _laserAmmo;

        public void UpdatePlayerMoveInfo(IInputMovable player)
        {
            _position.text = $"Position: {(Vector2)player.GetPosition()}";
            _rotation.text = $"Rotation: {player.GetRotation().eulerAngles.z:0}";
        }

        public void UpdatePlayerSpeed(float speed)
        {
            _speed.text = $"Speed: {speed:0.00}";
        }

        public void UpdateLaserInfo(float reloadPercent, int laserAmmo)
        {
            _laserReload.fillAmount = reloadPercent;
            _laserAmmo.text = laserAmmo.ToString();
        }
    }
}