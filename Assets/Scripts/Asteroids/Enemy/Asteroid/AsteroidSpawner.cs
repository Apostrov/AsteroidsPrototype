using System.Collections.Generic;
using Asteroids.Enemy.Data;
using Asteroids.Enemy.Spawner;
using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsFly;
using Asteroids.ObjectsPool;
using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Enemy.Asteroid
{
    public class AsteroidSpawner : RandomPositionSpawner
    {
        private readonly EnemyConfig _config;
        private readonly Dictionary<EnemyType, IObjectPool<GameObject>> _pools;

        public AsteroidSpawner(EnemyConfig config, EnemySpawnConfig spawnConfig, Camera camera) : base(spawnConfig,
            camera)
        {
            _config = config;
            _pools = new Dictionary<EnemyType, IObjectPool<GameObject>>
            {
                [EnemyType.AsteroidBig] = CreatePool(EnemyType.AsteroidBig),
                [EnemyType.AsteroidMedium] = CreatePool(EnemyType.AsteroidMedium),
                [EnemyType.AsteroidSmall] = CreatePool(EnemyType.AsteroidSmall)
            };
        }

        protected override void Spawn(EnemySpawnConfig spawnConfig, Vector3 spawnPosition)
        {
            var asteroid = _pools[spawnConfig.Type].Get();
            asteroid.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
            AfterSpawnEnemyInit(asteroid, spawnConfig);
        }

        private void AfterSpawnEnemyInit(GameObject asteroid, EnemySpawnConfig spawnConfig)
        {
            asteroid.transform.rotation = GetRandomRotation();

            if (asteroid.TryGetComponentInChildren(out IFly flier))
            {
                flier.SetFlyVector(Random.insideUnitCircle * spawnConfig.SpeedRange.GetRandomInRange());
            }

            if (asteroid.TryGetComponentInChildren(out IDestructible destructible))
            {
                destructible.SetOnDestroyListener(enemy => AsteroidSpawnOnDestroy(enemy, spawnConfig));
            }
        }

        private void AsteroidSpawnOnDestroy(GameObject toDestroy, EnemySpawnConfig spawnConfig)
        {
            if (spawnConfig.Type == EnemyType.AsteroidBig)
            {
                SpawnAsteroid(EnemyType.AsteroidMedium, toDestroy.transform.position);
            }

            if (spawnConfig.Type == EnemyType.AsteroidMedium)
            {
                SpawnAsteroid(EnemyType.AsteroidSmall, toDestroy.transform.position);
            }
        }

        private void SpawnAsteroid(EnemyType type, Vector3 position)
        {
            foreach (var enemySpawn in _config.EnemySpawnConfigs)
            {
                if (enemySpawn.Type == type)
                {
                    var pool = _pools[enemySpawn.Type];
                    for (int i = 0; i < _config.AsteroidsOnDestroySpawnRange.GetRandomInRange(); i++)
                    {
                        var asteroid = pool.Get();
                        asteroid.transform.SetPositionAndRotation(position, Quaternion.identity);
                        AfterSpawnEnemyInit(asteroid, enemySpawn);
                    }
                }
            }
        }

        private IObjectPool<GameObject> CreatePool(EnemyType type)
        {
            foreach (var enemySpawn in _config.EnemySpawnConfigs)
            {
                if (enemySpawn.Type == type)
                {
                    var pool = new SimplePool(enemySpawn.Prefab);
                    return pool.GetPool();
                }
            }

            Debug.LogError("EnemyConfig filled out incorrectly");
            return null;
        }

        private Quaternion GetRandomRotation()
        {
            return Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        }
    }
}