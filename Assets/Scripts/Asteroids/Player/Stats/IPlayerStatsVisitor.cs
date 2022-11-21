using Asteroids.Player.Move;

namespace Asteroids.Player.Stats
{
    public interface IPlayerStatsVisitor
    {
        void UpdatePlayerMoveInfo(IInputMovable player);
        void UpdatePlayerSpeed(float speed);
        void UpdateLaserInfo(float reloadPercent, int laserAmmo);
    }
}