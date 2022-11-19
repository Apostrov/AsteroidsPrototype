using UnityEngine;

namespace Asteroids.Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Asteroids/Data/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Spawner")]
        public EnemySpawnConfig Asteroid;
        public EnemySpawnConfig Alien;
        
        [Header("Asteroids")]
        public Vector2 AsteroidSpeedRange;
    }

    [System.Serializable]
    public class EnemySpawnConfig
    {
        public GameObject Prefab;
        public Vector2 SpawnTimeRange;
    }
}