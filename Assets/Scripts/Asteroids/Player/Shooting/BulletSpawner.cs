using Asteroids.ObjectsFly;
using Asteroids.ObjectsLimitedLifetime;
using Asteroids.ObjectsPool;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Player.Shooting
{
    public class BulletSpawner
    {
        private readonly IObjectPool<GameObject> _bulletsPool;
        private readonly IInputMovable _player;
        private readonly PlayerConfig _playerConfig;
        private readonly ILifeTimeChecker _lifeTimeChecker;

        public BulletSpawner(PlayerConfig playerConfig, IInputMovable player, ILifeTimeChecker lifeTimeChecker)
        {
            _bulletsPool = new SimplePool(playerConfig.BulletPrefab).GetPool();
            _player = player;
            _playerConfig = playerConfig;
            _lifeTimeChecker = lifeTimeChecker;
        }

        public void Spawn()
        {
            var bullet = _bulletsPool.Get();
            var playerRotation = _player.GetRotation();
            var position = _player.GetPosition() + playerRotation * _playerConfig.ProjectileSpawnOffset;
            bullet.transform.SetPositionAndRotation(position, Quaternion.identity);

            if (bullet.TryGetComponent(out IFly bulletFlyer))
            {
                bulletFlyer.SetFlyVector(playerRotation * Vector3.up * _playerConfig.BulletSpeed);
            }

            if (bullet.TryGetComponent(out IMortal mortalBullet))
            {
                mortalBullet.SetLifeTime(_playerConfig.BulletLifeTime);
                _lifeTimeChecker.Register(mortalBullet);
            }
        }
    }
}