using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.Player.Animation
{
    public class AnimatePlayerInputListener
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerAnimation _player;
        
        public AnimatePlayerInputListener(IPlayerAnimation player, IStateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }
        
        public void UpdateMoveInput(Vector2 inputVector)
        {
            if (inputVector.y > 0f && _stateMachine.GetCurrentState() == State.Gameplay)
            {
                _player.OnFly();
            }
            else
            {
                _player.OnIdle();
            }
        }
    }
}