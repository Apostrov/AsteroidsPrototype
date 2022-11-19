using UnityEngine;

namespace Asteroids.Enemy.Asteroid
{
    public class RandomizeSpriteComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Sprite[] _visual;
        
        public void Awake()
        {
            _renderer.sprite = _visual.GetRandomElement();
        }
    }
}