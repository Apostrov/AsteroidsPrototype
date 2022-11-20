using System;
using Asteroids.ObjectsDestoyer;
using UnityEngine;

namespace Asteroids.Player.Destroyer
{
    public class PlayerDestructibleComponent : MonoBehaviour, IDestructible
    {
        [SerializeField] private GameObject ToDestroy;
        private Action<GameObject> _onDestroy;

        public void SetBeforeDestroyAction(Action<GameObject> onDestroy)
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