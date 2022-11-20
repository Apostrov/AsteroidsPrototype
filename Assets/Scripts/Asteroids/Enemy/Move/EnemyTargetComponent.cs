using UnityEngine;

namespace Asteroids.Enemy.MoveToTarget
{
    public class EnemyTargetComponent : MonoBehaviour, ITarget
    {
        [SerializeField] private Transform Root;
        
        public Transform GetTarget()
        {
            return Root;
        }
    }
}