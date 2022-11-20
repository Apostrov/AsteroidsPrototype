using System;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public class EnemyDestructibleComponent : MonoBehaviour, IEnemyDestructible
    {
        [SerializeField] private GameObject ToDestroy;
        
        private Action<GameObject> _onDestroy;
        
        public void SetOnDestroyAction(Action<GameObject> onDestroy)
        {
            _onDestroy = onDestroy;
        }
        
        public void EnemyDestroy()
        {
            _onDestroy?.Invoke(ToDestroy);
        }
    }
}