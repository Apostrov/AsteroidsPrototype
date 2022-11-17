namespace Asteroids.ObjectsLimitedLifetime
{
    public interface ILifeTimeChecker
    {
        void Register(IMortal mortal);
    }
}