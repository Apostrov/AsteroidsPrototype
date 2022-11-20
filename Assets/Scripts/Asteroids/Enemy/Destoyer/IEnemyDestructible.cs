using System;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public interface IEnemyDestructible
    {
        void SetBeforeDestroyAction(Action<GameObject> onDestroy);
        void EnemyDestroy();
    }
}