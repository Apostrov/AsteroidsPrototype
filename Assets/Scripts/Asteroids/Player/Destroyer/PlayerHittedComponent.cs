using Asteroids.ObjectsDestoyer;
using UnityEngine;

namespace Asteroids.Player.Destroyer
{
    public class PlayerHittedComponent : MonoBehaviour
    {
        [SerializeField] private GameObject Root;

        private IDestructible _player;

        private void Awake()
        {
            _player = Root.GetComponentInChildren<IDestructible>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                if (col.TryGetComponent(out IDestructible destructible))
                {
                    destructible.ObjectDestroy();
                    _player.ObjectDestroy();
                }
            }
        }
    }
}