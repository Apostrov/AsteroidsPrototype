using Asteroids.Enemy.Data;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Enemy.Spawner
{
    public class RandomPositionSpawner : IUpdate
    {
        private readonly EnemySpawnConfig _config;
        private readonly Camera _camera;

        private float _spawnReload;

        public RandomPositionSpawner(EnemySpawnConfig config, Camera camera)
        {
            _config = config;
            _camera = camera;
            _spawnReload = GetSpawnReload();
        }

        public void Update()
        {
            _spawnReload -= Time.deltaTime;
            if (_spawnReload <= 0.0f)
            {
                _spawnReload = GetSpawnReload();
                Spawn();
            }
        }

        private float GetSpawnReload()
        {
            return _config.SpawnTimeRange.GetRandomInRange();
        }

        private void Spawn()
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
            Object.Instantiate(_config.Prefab, position, Quaternion.identity);
        }
    }
}