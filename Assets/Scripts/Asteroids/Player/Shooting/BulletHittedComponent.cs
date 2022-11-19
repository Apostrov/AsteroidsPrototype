using Asteroids.Enemy.Destoyer;
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
                if (col.TryGetComponent(out IEnemyDestructible destructible))
                {
                    destructible.EnemyDestroy();
                    _bullet.Kill();
                }
            }
        }
    }
}