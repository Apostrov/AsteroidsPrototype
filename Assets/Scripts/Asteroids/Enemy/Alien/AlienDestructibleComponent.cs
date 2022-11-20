using System;
using Asteroids.ObjectsDestoyer;
using UnityEngine;

namespace Asteroids.Enemy.Alien
{
    public class AlienDestructibleComponent : MonoBehaviour, IDestructible
    {
        [SerializeField] private GameObject ToDestroy;

        private Action<GameObject> _beforeDestroy;

        public void SetBeforeDestroyAction(Action<GameObject> onDestroy)
        {
            _beforeDestroy = onDestroy;
        }

        public void ObjectDestroy()
        {
            _beforeDestroy?.Invoke(ToDestroy);
            Destroy(ToDestroy);
        }
    }
}