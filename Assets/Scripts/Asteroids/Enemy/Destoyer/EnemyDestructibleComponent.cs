using System;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public class EnemyDestructibleComponent : MonoBehaviour, IEnemyDestructible
    {
        [SerializeField] private GameObject ToDestroy;
        
        private event Action<GameObject> OnDestroy;
        
        public void OnDestroyAction(Action<GameObject> onDestroy)
        {
            OnDestroy += onDestroy;
        }
        
        public void EnemyDestroy()
        {
            OnDestroy?.Invoke(ToDestroy);
        }
    }
}