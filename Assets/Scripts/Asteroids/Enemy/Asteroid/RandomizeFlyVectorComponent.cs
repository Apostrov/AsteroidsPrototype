using Asteroids.Enemy.Data;
using Asteroids.ObjectsFly;
using UnityEngine;

namespace Asteroids.Enemy.Asteroid
{
    public class RandomizeFlyVectorComponent: MonoBehaviour
    {
        [SerializeField] private EnemyConfig Config;
        [SerializeField] private GameObject Root;

        public void Awake()
        {
            Root.GetComponent<IFly>().SetFlyVector(Random.insideUnitCircle * Config.AsteroidSpeedRange.GetRandomInRange());
        }
    }
}