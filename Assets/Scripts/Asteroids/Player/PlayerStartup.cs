using System.Collections.Generic;
using Asteroids.Input;
using Asteroids.ObjectsLimitedLifetime;
using Asteroids.Player.Animation;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using Asteroids.Player.Shooting;
using Asteroids.Pool;
using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerStartup : MonoBehaviour
    {
        [SerializeField] private PlayerConfig PlayerConfig;

        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;

        private readonly List<IUpdate> _toUpdate = new();

        private void Awake()
        {
            CreatePlayer();
        }

        private void Update()
        {
            foreach (var update in _toUpdate)
            {
                update.Update();
            }
        }

        private void CreatePlayer()
        {
            var player = Instantiate(PlayerConfig.PlayerPrefab, Vector3.zero, Quaternion.identity);
            
            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                var movePlayerInputListener = new MovePlayerInputListener(PlayerConfig, playerMovable);
                InputBinder.SubscribeToMoveVectorChange(movePlayerInputListener.UpdateMoveInput);
                _toUpdate.Add(movePlayerInputListener);

                CreateShooting(playerMovable);
            }

            if (player.TryGetComponent(out IPlayerAnimation playerAnimation))
            {
                var animatePlayerInputListener = new AnimatePlayerInputListener(playerAnimation);
                InputBinder.SubscribeToMoveVectorChange(animatePlayerInputListener.UpdateMoveInput);
            }
        }

        private void CreateShooting(IInputMovable playerMovable)
        {
            var bulletPool = new SimplePool(PlayerConfig.BulletPrefab);
            var lifeTimeChecker = new MortalLifeTimeChecker(0.12f);
            var bulletSpawner = new BulletSpawner(PlayerConfig, bulletPool.GetPool(), playerMovable, lifeTimeChecker);
            var fireInputListener = new FireInputListener(bulletSpawner);
            InputBinder.SubscribeToFirePress(fireInputListener.GetFireSignal);
            
            _toUpdate.Add(lifeTimeChecker);
        }
    }
}