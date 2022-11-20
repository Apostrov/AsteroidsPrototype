﻿using System;
using UnityEngine;

namespace Asteroids.ObjectsLimitedLifetime
{
    public class MortalObjectComponent : MonoBehaviour, IMortal
    {
        private event Action OnDestroy;
        private event Action OnKill;
        
        private float _lifeTime;
        private bool _isAlive;

        public void SetDestroyAction(Action callback)
        {
            OnDestroy += callback;
        }

        public void SetKillAction(Action callback)
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
            OnDestroy?.Invoke();
        }

        public void Kill()
        {
            OnKill?.Invoke();
            DestroyObject();
        }
    }
}