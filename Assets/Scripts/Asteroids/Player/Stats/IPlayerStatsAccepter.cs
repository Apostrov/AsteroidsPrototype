namespace Asteroids.Player.Stats
{
    public interface IPlayerStatsAccepter
    {
        void Accept(IPlayerStatsVisitor playerStatsVisitor);
    }
}