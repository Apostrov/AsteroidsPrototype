using UnityEngine;

namespace Asteroids.Player.Animation
{
    public class AnimatePlayerInputListener
    {
        private readonly IPlayerAnimation _player;
        
        public AnimatePlayerInputListener(IPlayerAnimation player)
        {
            _player = player;
        }
        
        public void UpdateMoveInput(Vector2 inputVector)
        {
            if (inputVector.y > 0f)
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