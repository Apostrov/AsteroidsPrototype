using Asteroids.Data;
using Asteroids.Input;
using Asteroids.Move;
using Asteroids.Player;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsStartup : MonoBehaviour
    {
        [SerializeField] private PlayerMover PlayerMover;
        
        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;
        [SerializeField] private MovementConfig MovementConfig;

        private void Awake()
        {
            var inputEventListener = new MovePlayerInputListener(MovementConfig, new IMovable[] { PlayerMover });
            InputBinder.SubscribeToMoveVectorChange(inputEventListener.UpdateMoveInput);
        }
    }
}