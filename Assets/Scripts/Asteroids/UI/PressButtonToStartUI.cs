using Asteroids.StateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class PressButtonToStartUI : MonoBehaviour
    {
        [SerializeField] private SimpleStateMachine StateMachine;
        [SerializeField] private Button StartButton;

        private void Start()
        {
            StartButton.onClick.AddListener(() => StateMachine.ChangeState(State.Gameplay));
            StateMachine.AddOnStateExitListener(state =>
            {
                if (state == State.GameStart)
                {
                    gameObject.SetActive(false);
                }
            });
        }
    }
}