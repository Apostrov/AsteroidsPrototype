using System.Collections.Generic;
using Asteroids.Enemy.Data;
using Asteroids.ObjectsFly;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Enemy.MoveToTarget
{
    public class ToTargetMover : IUpdate, IMover
    {
        private readonly float _moveSpeed;
        private readonly List<IFly> _targetable;
        private readonly float _findTargetEvery;

        private Transform _target;
        private Vector3 _lastTargetPosition;
        private float _lastCheckTime;

        public ToTargetMover(EnemySpawnConfig config, float findTargetEvery)
        {
            _moveSpeed = config.SpeedRange.GetRandomInRange();
            _findTargetEvery = findTargetEvery;
            _targetable = new List<IFly>();
        }
        
        public void Update()
        {
            UpdateTargetPosition();
            
            foreach (var flier in _targetable)
            {
                flier.SetFlyVector(Quaternion.LookRotation(_lastTargetPosition - flier.GetPosition()) * Vector3.forward * _moveSpeed);
            }
        }

        private void UpdateTargetPosition()
        {
            if(Time.time - _lastCheckTime < _findTargetEvery)
                return;

            _lastCheckTime = Time.time;

            if (_target == null)
            {
                if (!GameObject.FindWithTag("Player").TryGetComponentInChildren<ITarget>(out var target))
                    return;
                
                _target = target.GetTarget();
            }

            _lastTargetPosition = _target.position;
        }

        public void AddMovable(IFly movable)
        {
            _targetable.Add(movable);
        }

        public void RemoveMovable(IFly movable)
        {
            _targetable.Remove(movable);
        }
    }
}