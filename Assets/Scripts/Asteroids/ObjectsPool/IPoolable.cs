using System;
using UnityEngine;

namespace Asteroids.ObjectsPool
{
    public interface IPoolable
    {
        void SetOnReturnToPoolListener(Action<GameObject> callback);
    }
}