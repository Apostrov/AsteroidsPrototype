using System;

namespace Asteroids.Pool
{
    public interface IPoolable
    {
        void SetPoolAction(Action callback);
        void Pool();
    }
}