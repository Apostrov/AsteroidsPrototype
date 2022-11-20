using Asteroids.Enemy.Data;
using Asteroids.Enemy.Destoyer;
using Asteroids.Enemy.Spawner;
using Asteroids.ObjectsFly;
using UnityEngine;

namespace Asteroids.Enemy.Asteroid
{
    public class AsteroidSpawner : RandomPositionSpawner
    {
        private readonly EnemyConfig _config;

        public AsteroidSpawner(EnemyConfig config, EnemySpawnConfig spawnConfig, Camera camera) : base(spawnConfig,
            camera)
        {
            _config = config;
        }

        protected override void AfterSpawnEnemyInit(GameObject asteroid, EnemySpawnConfig spawnConfig)
        {
            asteroid.transform.rotation = GetRandomRotation();

            if (asteroid.TryGetComponentInChildren(out IFly flier))
            {
                flier.SetFlyVector(Random.insideUnitCircle * spawnConfig.SpeedRange.GetRandomInRange());
            }

            if (asteroid.TryGetComponentInChildren(out IEnemyDestructible destructible))
            {
                destructible.OnDestroyAction(enemy => AsteroidSpawnOnDestroy(enemy, spawnConfig));
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
            
            Object.Destroy(toDestroy);
        }

        private void SpawnAsteroid(EnemyType type, Vector3 position)
        {
            foreach (var enemySpawn in _config.EnemySpawnConfigs)
            {
                if (enemySpawn.Type == type)
                {
                    var asteroid = Object.Instantiate(enemySpawn.Prefab, position, Quaternion.identity);
                    AfterSpawnEnemyInit(asteroid, enemySpawn);
                }
            }
        }

        private Quaternion GetRandomRotation()
        {
            return Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));
        }
    }
}