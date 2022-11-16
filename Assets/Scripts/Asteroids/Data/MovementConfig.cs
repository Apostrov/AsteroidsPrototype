using UnityEngine;

namespace Asteroids.Data
{
    [CreateAssetMenu(fileName = "MovementConfig", menuName = "Asteroids/Data/MovementConfig")]
    public class MovementConfig : ScriptableObject
    {
        public float AccelerationGrowSpeed = 0.25f;
        public float BreakForce = 0.25f;
        public float MaxSpeed = 8f;
        public float MaxAcceleration = 5f;

        [Range(0f, 1f)]
        public float InertialLerp = 0.1f;
        public float AngularSpeed = 90f;
    }
}