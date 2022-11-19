using UnityEngine;

namespace Asteroids.Enemy.Asteroid
{
    public class RandomizeSpriteComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer Renderer;
        [SerializeField] private Sprite[] Visual;
        
        public void Awake()
        {
            Renderer.sprite = Visual.GetRandomElement();
        }
    }
}