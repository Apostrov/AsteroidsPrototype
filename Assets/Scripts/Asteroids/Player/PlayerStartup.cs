using System.Collections.Generic;
using Asteroids.Data;
using Asteroids.Input;
using Asteroids.Player.Animation;
using Asteroids.Player.Move;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerStartup : MonoBehaviour
    {
        [SerializeField] private GameObject PlayerPrefab;

        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;
        [SerializeField] private MovementConfig MovementConfig;

        private readonly List<IUpdate> _toUpdate = new();

        private void Awake()
        {
            var player = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);

            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                var movePlayerInputListener = new MovePlayerInputListener(MovementConfig, playerMovable);
                InputBinder.SubscribeToMoveVectorChange(movePlayerInputListener.UpdateMoveInput);
                _toUpdate.Add(movePlayerInputListener);
            }

            if (player.TryGetComponent(out IPlayerAnimation playerAnimation))
            {
                var animatePlayerInputListener = new AnimatePlayerInputListener(playerAnimation);
                InputBinder.SubscribeToMoveVectorChange(animatePlayerInputListener.UpdateMoveInput);
            }
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