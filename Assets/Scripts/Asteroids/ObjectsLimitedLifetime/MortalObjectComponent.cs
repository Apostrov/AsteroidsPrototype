using System;
using UnityEngine;

namespace Asteroids.ObjectsLimitedLifetime
{
    public class MortalObjectComponent : MonoBehaviour, IMortal
    {
        private event Action OnDestroy;
        
        private float _lifeTime;

        public void SetDestroyAction(Action callback)
        {
            OnDestroy += callback;
        }

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        public bool DecreaseLifeTime(float deltaTime)
        {
            _lifeTime -= deltaTime;
            if (_lifeTime <= 0.0f)
            {
                DestroyObject();
                return true;
            }
            return false;
        }

        private void DestroyObject()
        {
            OnDestroy?.Invoke();
        }

        public void Kill()
        {
            SetLifeTime(0f);
        }
    }
}