using System.Collections.Generic;
using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.ObjectsLimitedLifetime
{
    public class MortalLifeTimeChecker : IGameplayUpdate, ILifeTimeChecker
    {
        private readonly List<IMortal> _alive = new();
        private readonly float _checkEvery;

        private float _lastCheckTime;

        public MortalLifeTimeChecker(float checkEvery)
        {
            _checkEvery = checkEvery;
            _lastCheckTime = Time.time;
        }

        public void Register(IMortal mortal)
        {
            mortal.AddOnKillListener(() => OnKill(mortal));
            _alive.Add(mortal);
        }
        
        public void Update()
        {
            if (Time.time - _lastCheckTime >= _checkEvery)
            {
                _lastCheckTime = Time.time;
                CheckObjects();
            }
        }

        private void CheckObjects()
        {
            int i = 0;
            while (i < _alive.Count)
            {
                var currentObject = _alive[i];
                if (currentObject.DecreaseLifeTime(_checkEvery))
                {
                    _alive.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        private void OnKill(IMortal toKill)
        {
            _alive.Remove(toKill);
        }
    }
}