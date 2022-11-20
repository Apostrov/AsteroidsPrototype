using System;
using UnityEngine;

namespace Asteroids.Enemy.Destoyer
{
    public interface IEnemyDestructible
    {
        void SetOnDestroyAction(Action<GameObject> onDestroy);
        void EnemyDestroy();
    }
}