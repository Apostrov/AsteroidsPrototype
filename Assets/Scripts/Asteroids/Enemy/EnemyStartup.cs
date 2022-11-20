using System.Collections.Generic;
using Asteroids.Enemy.Alien;
using Asteroids.Enemy.Asteroid;
using Asteroids.Enemy.Data;
using Asteroids.Enemy.MoveToTarget;
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
            CreateAlienSpawner();
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

        private void CreateAlienSpawner()
        {
            foreach (var enemy in EnemyConfig.EnemySpawnConfigs)
            {
                if (enemy.Type == EnemyType.Alien)
                {
                    var mover = new ToTargetMover(enemy, 0.07f);
                    var asteroidSpawner = new AlienSpawner(mover, enemy, Camera.main);
                    
                    _toUpdate.Add(mover);
                    _toUpdate.Add(asteroidSpawner);
                }
            }
        }
    }
}