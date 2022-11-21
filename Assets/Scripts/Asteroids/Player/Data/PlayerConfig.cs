using UnityEngine;

namespace Asteroids.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Asteroids/Data/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Movements")]
        public float AccelerationGrowSpeed = 0.25f;
        public float BreakForce = 0.25f;
        public float MaxSpeed = 8f;
        public float MaxAcceleration = 5f;

        [Range(0f, 1f)]
        public float InertialLerp = 0.1f;
        public float AngularSpeed = 90f;

        [Header("Shooting")]
        public Vector3 ProjectileSpawnOffset = new(0f, 1f, 0f);
        
        [Header("Bullet")]
        public float BulletSpeed = 2f;
        public float BulletLifeTime = 1f;

        [Header("Laser")]
        public float LaserShowTime = 0.07f;
        public float LaserReload = 1f;
        public int LaserAmmo = 3;
        
        [Header("Prefabs")]
        public GameObject PlayerPrefab;
        public GameObject BulletPrefab;
        public GameObject LaserPrefab;
    }
}