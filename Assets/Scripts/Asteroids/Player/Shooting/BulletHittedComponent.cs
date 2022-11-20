using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsLimitedLifetime;
using UnityEngine;

namespace Asteroids.Player.Shooting
{
    public class BulletHittedComponent : MonoBehaviour
    {
        [SerializeField] private GameObject Root;

        private IMortal _bullet;

        private void Awake()
        {
            _bullet = Root.GetComponent<IMortal>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Enemy"))
            {
                if (col.TryGetComponent(out IDestructible destructible))
                {
                    destructible.ObjectDestroy();
                    _bullet.Kill();
                }
            }
        }
    }
}