using System;

namespace Asteroids.ObjectsLimitedLifetime
{
    public interface IMortal
    {
        void SetDestroyAction(Action callback);
        void SetKillAction(Action callback);
        void SetLifeTime(float lifeTime);
        bool DecreaseLifeTime(float deltaTime);
        void Kill();
    }
}