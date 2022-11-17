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
        public float BulletSpeed = 2f;
        public Vector3 BulletSpawnOffset = new(0f, 1f, 0f);
    }
}