using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public class EnemyDestructibleComponent : MonoBehaviour, IEnemyDestructible
    {
        [SerializeField] private GameObject _toDestroy;
        
        public void EnemyDestroy()
        {
            Destroy(_toDestroy);
        }
    }
}