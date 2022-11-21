using System.Collections.Generic;
using Asteroids.StateMachine;

namespace Asteroids.Player.Stats
{
    public class PlayerStatsUpdater : IGameplayUpdate, IPlayerStatsVisitorUpdate
    {
        private readonly IPlayerStatsVisitor _visitor;
        private readonly List<IPlayerStatsAccepter> _accepters;

        public PlayerStatsUpdater(IPlayerStatsVisitor visitor)
        {
            _visitor = visitor;
            _accepters = new List<IPlayerStatsAccepter>();
        }

        public void Update()
        {
            foreach (var info in _accepters)
            {
                info.Accept(_visitor);
            }
        }

        public void AddAccepter(IPlayerStatsAccepter accepter)
        {
            _accepters.Add(accepter);
        }
    }
}