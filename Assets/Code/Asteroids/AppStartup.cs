using Asteroids.Input;
using Asteroids.Move;
using Asteroids.Move.Data;
using Asteroids.Player;
using UnityEngine;

namespace Asteroids
{
    public class AppStartup : MonoBehaviour
    {
        [SerializeField] private PlayerView Player;
        
        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;
        [SerializeField] private MovementConfig MovementConfig;

        private void Awake()
        {
            var inputEventListener = new InputEventListener(MovementConfig, new IMovable[] { Player });
            InputBinder.SubscribeToMoveVectorChange(inputEventListener.UpdateMoveInput);
        }
    }
}