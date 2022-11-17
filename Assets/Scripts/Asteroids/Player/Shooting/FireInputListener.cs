using Asteroids.ObjectsFly;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Player.Shooting
{
    public class FireInputListener
    {
        private readonly IObjectPool<GameObject> _bulletsPool;
        private readonly IInputMovable _player;
        private readonly PlayerConfig _playerConfig;

        public FireInputListener(IObjectPool<GameObject> bulletPool, IInputMovable player, PlayerConfig playerConfig)
        {
            _bulletsPool = bulletPool;
            _player = player;
            _playerConfig = playerConfig;
        }

        public void GetFlySignal()
        {
            var bullet = _bulletsPool.Get();
            var playerRotation = _player.GetRotation();
            bullet.transform.position = _player.GetPosition() + playerRotation * _playerConfig.BulletSpawnOffset;
            if (bullet.TryGetComponent(out IFly bulletFlyer))
            {
                bulletFlyer.SetFlyVector(playerRotation * Vector3.up * _playerConfig.BulletSpeed);
            }
        }
    }
}