using Asteroids.Enemy.Data;
using Asteroids.Enemy.MoveToTarget;
using Asteroids.Enemy.Spawner;
using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsFly;
using UnityEngine;

namespace Asteroids.Enemy.Alien
{
    public class AlienSpawner : RandomPositionSpawner
    {
        private readonly IMover _mover;

        public AlienSpawner(IMover mover, EnemySpawnConfig spawnConfig, Camera camera) : base(spawnConfig, camera)
        {
            _mover = mover;
        }

        protected override void Spawn(EnemySpawnConfig spawnConfig, Vector3 spawnPosition)
        {
            var alien = Object.Instantiate(spawnConfig.Prefab, spawnPosition, Quaternion.identity);

            if (alien.TryGetComponentInChildren(out IFly flier))
            {
                _mover.AddMovable(flier);

                if (alien.TryGetComponentInChildren(out IDestructible destructible))
                {
                    destructible.SetOnDestroyListener((_) => _mover.RemoveMovable(flier));
                }
            }
        }
    }
}