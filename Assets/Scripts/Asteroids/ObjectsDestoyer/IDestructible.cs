using System;
using UnityEngine;

namespace Asteroids.ObjectsDestoyer
{
    public interface IDestructible
    {
        void SetOnDestroyListener(Action<GameObject> onDestroy);
        void ObjectDestroy();
    }
}