using Asteroids.ObjectsDestoyer;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using UnityEngine;

namespace Asteroids.Player.Laser
{
    public class LaserShooter
    {
        private readonly IInputMovable _player;
        private readonly PlayerConfig _playerConfig;
        private readonly LaserVisualComponent _laser;

        private readonly RaycastHit2D[] _hitted = new RaycastHit2D[50];

        private float _lastShootTime;

        public LaserShooter(PlayerConfig playerConfig, IInputMovable player, LaserVisualComponent laser)
        {
            _player = player;
            _playerConfig = playerConfig;
            _laser = laser;
            _lastShootTime = Time.time;
        }

        public void Shoot()
        {
            if (Time.time - _lastShootTime < _playerConfig.LaserReload)
                return;

            _lastShootTime = Time.time;

            var playerRotation = _player.GetRotation();
            var shootDirection = playerRotation * Vector3.up;
            _laser.SetShootPoint(shootDirection * 100f, _playerConfig.LaserShowTime);
            HitNDestroy(_player.GetPosition(), shootDirection);
        }

        private void HitNDestroy(Vector2 from, Vector2 direction)
        {
            var hitted = Physics2D.RaycastNonAlloc(from, direction, _hitted, 100f, 1 << LayerMask.NameToLayer("Enemy"));
            for (int i = 0; i < hitted; i++)
            {
                var enemy = _hitted[i];
                if (enemy.transform.TryGetComponent(out IDestructible destructible))
                {
                    destructible.ObjectDestroy();
                }
            }
        }
    }
}