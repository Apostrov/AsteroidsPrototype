using UnityEngine;

namespace Asteroids.Move.Data
{
    [CreateAssetMenu(fileName = "MovementConfig", menuName = "Asteroids/Data/MovementConfig")]
    public class MovementConfig : ScriptableObject
    {
        public float Speed;
    }
}