using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsLimitedLifetime;
using Asteroids.ObjectsPool;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using Asteroids.Player.Stats;
using Asteroids.StateMachine;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Player.Laser
{
    public class LaserSpawner : IPlayerStatsAccepter, IGameplayUpdate
    {
        private readonly IObjectPool<GameObject> _laserPool;
        private readonly IInputMovable _player;
        private readonly PlayerConfig _playerConfig;
        private readonly ILifeTimeChecker _lifeTimeChecker;

        private readonly RaycastHit2D[] _hitted = new RaycastHit2D[50];

        private float _reloadTime;
        private int _currentAmmo;

        public LaserSpawner(PlayerConfig playerConfig, IInputMovable player, ILifeTimeChecker lifeTimeChecker)
        {
            _player = player;
            _playerConfig = playerConfig;
            _reloadTime = playerConfig.LaserReload;
            _currentAmmo = 0;
            _laserPool = new SimplePool(playerConfig.LaserPrefab).GetPool();
            _lifeTimeChecker = lifeTimeChecker;
        }

        public void Update()
        {
            if (_currentAmmo < _playerConfig.LaserAmmo)
            {
                _reloadTime -= Time.deltaTime;
                if (_reloadTime <= 0f)
                {
                    _currentAmmo++;
                    _reloadTime = _playerConfig.LaserReload;
                }
            }
        }

        public void Spawn()
        {
            if (_currentAmmo < 1)
                return;

            _currentAmmo--;
            var laser = _laserPool.Get();
            var playerRotation = _player.GetRotation();
            var playerPosition = _player.GetPosition();
            var spawnPosition = playerPosition + playerRotation * _playerConfig.ProjectileSpawnOffset;
            laser.transform.SetPositionAndRotation(spawnPosition, playerRotation);

            if (laser.TryGetComponent(out IMortal mortal))
            {
                mortal.SetLifeTime(_playerConfig.LaserShowTime);
                _lifeTimeChecker.Register(mortal);
            }

            LaserHitAndDestroy(playerPosition, playerRotation * Vector3.up);
        }

        private void LaserHitAndDestroy(Vector2 from, Vector2 direction)
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

        public void Accept(IPlayerStatsVisitor playerStatsVisitor)
        {
            playerStatsVisitor.UpdateLaserInfo(1f - _reloadTime / _playerConfig.LaserReload, _currentAmmo);
        }
    }
}