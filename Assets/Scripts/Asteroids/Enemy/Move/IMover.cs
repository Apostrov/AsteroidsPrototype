using Asteroids.ObjectsFly;

namespace Asteroids.Enemy.MoveToTarget
{
    public interface IMover
    {
        void AddMovable(IFly movable);
        void RemoveMovable(IFly movable);
    }
}