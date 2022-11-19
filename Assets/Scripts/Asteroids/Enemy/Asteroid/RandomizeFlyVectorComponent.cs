using Asteroids.Enemy.Data;
using Asteroids.ObjectsFly;
using UnityEngine;

namespace Asteroids.Enemy.Asteroid
{
    public class RandomizeFlyVectorComponent: MonoBehaviour
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private SimpleFlyerComponent _flyerComponent;

        public void Awake()
        {
            _flyerComponent.SetFlyVector(Random.insideUnitCircle * _config.AsteroidSpeedRange.GetRandomInRange());
        }
    }
}