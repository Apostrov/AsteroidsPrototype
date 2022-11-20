using System;
using UnityEngine;

namespace Asteroids.ObjectsPool
{
    public interface IPoolable
    {
        void SetReturnToPoolAction(Action<GameObject> callback);
    }
}