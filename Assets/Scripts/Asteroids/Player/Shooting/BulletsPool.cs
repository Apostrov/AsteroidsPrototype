using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Player.Shooting
{
    public class BulletsPool
    {
        private readonly GameObject _bulletPrefab;
        private readonly IObjectPool<GameObject> _pool;

        public BulletsPool(GameObject bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
            _pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
        }
        
        public IObjectPool<GameObject> GetPool()
        {
            return _pool;
        }
        
        GameObject CreatePooledItem()
        {
            var bullet = Object.Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity);
            return bullet;
        }

        // Called when an item is returned to the pool using Release
        void OnReturnedToPool(GameObject bullet)
        {
            bullet.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        void OnTakeFromPool(GameObject bullet)
        {
            bullet.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        void OnDestroyPoolObject(GameObject bullet)
        {
            Object.Destroy(bullet);
        }
    }
}