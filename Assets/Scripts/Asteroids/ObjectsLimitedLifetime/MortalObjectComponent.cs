using System;
using Asteroids.ObjectsPool;
using UnityEngine;

namespace Asteroids.ObjectsLimitedLifetime
{
    public class MortalObjectComponent : MonoBehaviour, IMortal, IPoolable
    {
        [SerializeField] private GameObject ToDestroy;
        
        private event Action OnKill;
        private Action<GameObject>  _onPool;
        
        private float _lifeTime;
        private bool _isAlive;

        public void SetReturnToPoolAction(Action<GameObject> callback)
        {
            _onPool = callback;
        }

        public void AddKillAction(Action callback)
        {
            OnKill += callback;
        }

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
            _isAlive = _lifeTime > 0f;
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
            if(!_isAlive)
                return;
            
            _isAlive = false;
            _onPool?.Invoke(ToDestroy);
        }

        public void Kill()
        {
            OnKill?.Invoke();
            DestroyObject();
        }
    }
}