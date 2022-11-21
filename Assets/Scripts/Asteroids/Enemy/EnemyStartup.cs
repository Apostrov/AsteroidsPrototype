using Asteroids.Enemy.Alien;
using Asteroids.Enemy.Asteroid;
using Asteroids.Enemy.Data;
using Asteroids.Enemy.MoveToTarget;
using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.Enemy
{
    public class EnemyStartup : MonoBehaviour
    {
        [SerializeField] private EnemyConfig EnemyConfig;
        [SerializeField] private SimpleStateMachine StateMachine;

        private void Awake()
        {
            StateMachine.AddOnStateEnterListener(state =>
            {
                if (state == State.GameStart)
                {
                    CreateAsteroidSpawner();
                    CreateAlienSpawner();
                }
            });
        }

        private void CreateAsteroidSpawner()
        {
            foreach (var enemy in EnemyConfig.EnemySpawnConfigs)
            {
                if (enemy.Type == EnemyType.AsteroidBig)
                {
                    var asteroidSpawner = new AsteroidSpawner(EnemyConfig, enemy, Camera.main);
                    StateMachine.AddGameplayUpdate(asteroidSpawner);
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

                    StateMachine.AddGameplayUpdate(mover);
                    StateMachine.AddGameplayUpdate(asteroidSpawner);
                }
            }
        }
    }
}