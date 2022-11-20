using System;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public interface IEnemyDestructible
    {
        void OnDestroyAction(Action<GameObject> onDestroy);
        void EnemyDestroy();
    }
}