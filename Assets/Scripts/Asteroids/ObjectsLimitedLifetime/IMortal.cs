using System;

namespace Asteroids.ObjectsLimitedLifetime
{
    public interface IMortal
    {
        void AddKillAction(Action callback);
        void SetLifeTime(float lifeTime);
        bool DecreaseLifeTime(float deltaTime);
        void Kill();
    }
}