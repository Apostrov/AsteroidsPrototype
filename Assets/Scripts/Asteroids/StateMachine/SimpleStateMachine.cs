using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.StateMachine
{
    public class SimpleStateMachine : MonoBehaviour, IStateMachine
    {
        private event Action<State> OnStateEnter;
        private event Action<State> OnStateExit;

        private readonly List<IGameplayUpdate> _toGameplayUpdate = new();
        private State _currentState = State.Loading;

        private void Start()
        {
            ChangeState(State.GameStart);
        }

        private void Update()
        {
            if (_currentState == State.Gameplay)
            {
                foreach (var update in _toGameplayUpdate)
                {
                    update.Update();
                }
            }
        }

        public void AddGameplayUpdate(IGameplayUpdate updatable)
        {
            _toGameplayUpdate.Add(updatable);
        }

        public void ChangeState(State newState)
        {
            OnStateExit?.Invoke(_currentState);
            _currentState = newState;
            OnStateEnter?.Invoke(newState);
        }

        public void AddOnStateEnterListener(Action<State> callback)
        {
            OnStateEnter += callback;
        }

        public void AddOnStateExitListener(Action<State> callback)
        {
            OnStateExit += callback;
        }

        public State GetCurrentState()
        {
            return _currentState;
        }
    }
}