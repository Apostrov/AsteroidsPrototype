using System;

namespace Asteroids.StateMachine
{
    public interface IStateMachine
    {
        void AddGameplayUpdate(IGameplayUpdate updatable);
        void ChangeState(State newState);
        void AddOnStateEnterListener(Action<State> callback);
        void AddOnStateExitListener(Action<State> callback);
        State GetCurrentState();
    }

    public enum State
    {
        Loading,
        GameStart,
        Gameplay,
        GameEnd
    }
}