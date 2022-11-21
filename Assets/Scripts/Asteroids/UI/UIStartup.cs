using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.UI
{
    public class UIStartup : MonoBehaviour
    {
        [SerializeField] private SimpleStateMachine StateMachine;
        [SerializeField] private StateUI[] StateUis;

        private void Awake()
        {
            OnStatEnter(State.Loading);
            StateMachine.AddOnStateEnterListener(OnStatEnter);
        }

        private void OnStatEnter(State state)
        {
            foreach (var stateUi in StateUis)
            {
                stateUi.UI.SetActive(stateUi.State == state);
            }
        }
    }

    [System.Serializable]
    public class StateUI
    {
        public State State;
        public GameObject UI;
    }
}