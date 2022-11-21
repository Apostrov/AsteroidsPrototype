namespace Asteroids.Player.Stats
{
    public interface IPlayerStatsVisitorUpdate
    {
        void AddAccepter(IPlayerStatsAccepter accepter);
    }
}