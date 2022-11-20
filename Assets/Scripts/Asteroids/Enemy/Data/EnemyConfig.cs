using UnityEngine;

namespace Asteroids.Enemy.Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Asteroids/Data/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Spawner")]
        public EnemySpawnConfig[] EnemySpawnConfigs;

        [Header("Asteroid")]
        public Vector2Int AsteroidsOnDestroySpawnRange;
    }

    [System.Serializable]
    public class EnemySpawnConfig
    {
        public EnemyType Type;
        public GameObject Prefab;
        public Vector2 SpawnTimeRange;
        public Vector2 SpeedRange;
    }

    public enum EnemyType
    {
        AsteroidBig,
        AsteroidMedium,
        AsteroidSmall,
        Alien
    }
}