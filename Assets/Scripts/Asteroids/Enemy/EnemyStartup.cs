using System.Collections.Generic;
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
            var asteroidSpawner = new RandomPositionSpawner(EnemyConfig.Asteroid, Camera.main);
            
            _toUpdate.Add(asteroidSpawner);
        }

        private void Update()
        {
            foreach (var update in _toUpdate)
            {
                update.Update();
            }
        }
    }
}