using Asteroids.Input;
using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsLimitedLifetime;
using Asteroids.Player.Animation;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using Asteroids.Player.Shooting;
using Asteroids.ObjectsPool;
using Asteroids.Player.Laser;
using Asteroids.StateMachine;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerStartup : MonoBehaviour
    {
        [SerializeField] private PlayerConfig PlayerConfig;
        [SerializeField] private SimpleStateMachine StateMachine;

        [Header("Input and movements")]
        [SerializeField] private PlayerInputEventManager InputBinder;

        private void Awake()
        {
            StateMachine.AddOnStateEnterListener(state =>
            {
                if (state == State.GameStart)
                {
                    var player = CreatePlayer();
                    CreateShooting(player);
                }

                if (state == State.GameEnd)
                {
                    InputBinder.ClearSubscriptions();
                }
            });
        }

        private GameObject CreatePlayer()
        {
            var player = Instantiate(PlayerConfig.PlayerPrefab, Vector3.zero, Quaternion.identity);

            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                var movePlayerInputListener = new MovePlayerInputListener(PlayerConfig, playerMovable);
                InputBinder.AddOnMoveListener(movePlayerInputListener.UpdateMoveInput);
                StateMachine.AddGameplayUpdate(movePlayerInputListener);
            }

            if (player.TryGetComponent(out IPlayerAnimation playerAnimation))
            {
                var animatePlayerInputListener = new AnimatePlayerInputListener(playerAnimation, StateMachine);
                InputBinder.AddOnMoveListener(animatePlayerInputListener.UpdateMoveInput);
            }

            if (player.TryGetComponent(out IDestructible destructible))
            {
                destructible.SetOnDestroyListener((_) => { StateMachine.ChangeState(State.GameEnd); });
            }

            return player;
        }

        private void CreateShooting(GameObject player)
        {
            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                var lifeTimeChecker = new MortalLifeTimeChecker(0.12f);
                var bulletSpawner = new BulletSpawner(PlayerConfig, playerMovable, lifeTimeChecker);

                InputBinder.AddOnFireListener(bulletSpawner.Spawn);
                StateMachine.AddGameplayUpdate(lifeTimeChecker);

                if (player.TryGetComponent(out LaserVisualComponent laserVisual))
                {
                    var laser = new LaserShooter(PlayerConfig, playerMovable, laserVisual);
                    InputBinder.AddOnLaserListener(laser.Shoot);
                }
            }
        }
    }
}