using System.Collections.Generic;
using Asteroids.Enemy.Asteroid;
using Asteroids.Enemy.Data;
using Asteroids.Enemy.Spawner;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Enemy
{
    public class EnemyStartup : MonoBehaviour
    {
        [SerializeField] private EnemyConfig EnemyConfig;
        
        private readonly List<IUpdate> _toUpdate = new();

        private void Awake()
        {
            CreateAsteroidSpawner();
        }

        private void Update()
        {
            foreach (var update in _toUpdate)
            {
                update.Update();
            }
        }

        private void CreateAsteroidSpawner()
        {
            foreach (var enemy in EnemyConfig.EnemySpawnConfigs)
            {
                if (enemy.Type == EnemyType.AsteroidBig)
                {
                    var asteroidSpawner = new AsteroidSpawner(EnemyConfig, enemy, Camera.main);
                    _toUpdate.Add(asteroidSpawner);
                }
            }
        }
    }
}