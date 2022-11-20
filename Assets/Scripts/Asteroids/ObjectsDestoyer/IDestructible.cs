using System;
using UnityEngine;

namespace Asteroids.ObjectsDestoyer
{
    public interface IDestructible
    {
        void SetBeforeDestroyAction(Action<GameObject> onDestroy);
        void ObjectDestroy();
    }
}