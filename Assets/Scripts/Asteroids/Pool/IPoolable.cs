using System;
using UnityEngine;

namespace Asteroids.Pool
{
    public interface IPoolable
    {
        void SetReturnToPoolAction(Action<GameObject> callback);
    }
}