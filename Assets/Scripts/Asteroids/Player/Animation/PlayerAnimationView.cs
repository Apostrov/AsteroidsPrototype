using UnityEngine;

namespace Asteroids.Player.Animation
{
    public class PlayerAnimationView : MonoBehaviour, IPlayerAnimation
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Sprite _idle;
        [SerializeField] private Sprite _fly;
        
        public void OnIdle()
        {
            _renderer.sprite = _idle;
        }

        public void OnFly()
        {
            _renderer.sprite = _fly;
        }
    }
}