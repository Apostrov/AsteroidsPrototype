using UnityEngine;
using UnityEngine.Pool;

namespace Asteroids.Pool
{
    public class SimplePool
    {
        private readonly GameObject _prefab;
        private readonly IObjectPool<GameObject> _pool;

        public SimplePool(GameObject prefab)
        {
            _prefab = prefab;
            _pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject);
        }
        
        public IObjectPool<GameObject> GetPool()
        {
            return _pool;
        }
        
        GameObject CreatePooledItem()
        {
            var item = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
            if (item.TryGetComponent(out IPoolable poolable))
            {
                poolable.SetPoolAction(() => _pool.Release(item));
            }
            return item;
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