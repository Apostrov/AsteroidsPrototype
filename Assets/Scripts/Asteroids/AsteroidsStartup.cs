using System.Collections.Generic;
using Asteroids.Data;
using Asteroids.Input;
using Asteroids.Move;
using Asteroids.Player;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidsStartup : MonoBehaviour
    {
        [SerializeField] private PlayerMoverView PlayerMover;
        
        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;
        [SerializeField] private MovementConfig MovementConfig;

        private readonly List<IUpdate> _toUpdate = new();

        private void Awake()
        {
            var inputEventListener = new MovePlayerInputListener(MovementConfig, new IInputMovable[] { PlayerMover });
            InputBinder.SubscribeToMoveVectorChange(inputEventListener.UpdateMoveInput);
            
            _toUpdate.Add(inputEventListener);
        }

        private void Update()
        {
            foreach (var update in _toUpdate)
            {
                update.Update();
            }
        }
    }
}