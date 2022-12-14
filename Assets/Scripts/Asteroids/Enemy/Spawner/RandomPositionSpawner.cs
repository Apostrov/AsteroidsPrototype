using Asteroid.Points;
using Asteroids.Enemy.Data;
using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.Enemy.Spawner
{
    public abstract class RandomPositionSpawner : IGameplayUpdate
    {
        private readonly EnemySpawnConfig _spawnConfig;
        private readonly Camera _camera;
        protected readonly IPointsCounter PointsCounter;

        private float _spawnReload;

        protected RandomPositionSpawner(EnemySpawnConfig spawnConfig, Camera camera, IPointsCounter counter)
        {
            _spawnConfig = spawnConfig;
            _camera = camera;
            _spawnReload = GetSpawnReload();
            PointsCounter = counter;
        }

        public void Update()
        {
            _spawnReload -= Time.deltaTime;
            if (_spawnReload <= 0.0f)
            {
                _spawnReload = GetSpawnReload();
                TryToSpawn();
            }
        }

        private float GetSpawnReload()
        {
            return _spawnConfig.SpawnTimeRange.GetRandomInRange();
        }

        private void TryToSpawn()
        {
            var randomScreenPosition = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));
            if (Physics.Raycast(_camera.ScreenPointToRay(randomScreenPosition), out var hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out ICantSpawnNear _))
                {
                    _spawnReload = 0.1f;
                    return;
                }
            }

            var position = _camera.ScreenToWorldPoint(randomScreenPosition);
            position.z = 0f;
            Spawn(_spawnConfig, position);
        }

        protected abstract void Spawn(EnemySpawnConfig spawnConfig, Vector3 spawnPosition);
    }
}