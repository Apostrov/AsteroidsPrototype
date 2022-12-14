using System;
using Asteroids.ObjectsDestoyer;
using UnityEngine;

namespace Asteroids.Enemy.Alien
{
    public class AlienDestructibleComponent : MonoBehaviour, IDestructible
    {
        [SerializeField] private GameObject ToDestroy;

        private Action<GameObject> _onDestroy;

        public void SetOnDestroyListener(Action<GameObject> onDestroy)
        {
            _onDestroy = onDestroy;
        }

        public void ObjectDestroy()
        {
            _onDestroy?.Invoke(ToDestroy);
            Destroy(ToDestroy);
        }
    }
}