﻿using System;
using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsPool;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public class EnemyDestructibleComponent : MonoBehaviour, IDestructible, IPoolable
    {
        [SerializeField] private GameObject ToDestroy;

        private Action<GameObject> _beforeDestroy;
        private Action<GameObject> _onPool;

        public void SetBeforeDestroyAction(Action<GameObject> onDestroy)
        {
            _beforeDestroy = onDestroy;
        }

        public void ObjectDestroy()
        {
            _beforeDestroy?.Invoke(ToDestroy);
            _onPool?.Invoke(ToDestroy);
        }

        public void SetReturnToPoolAction(Action<GameObject> callback)
        {
            _onPool = callback;
        }
    }
}