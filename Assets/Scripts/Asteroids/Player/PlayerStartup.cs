using Asteroids.Input;
using Asteroids.ObjectsDestoyer;
using Asteroids.ObjectsLimitedLifetime;
using Asteroids.Player.Animation;
using Asteroids.Player.Data;
using Asteroids.Player.Move;
using Asteroids.Player.Shooting;
using Asteroids.Player.Laser;
using Asteroids.Player.Stats;
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

        [Header("UI")]
        [SerializeField] private PlayerStatsUI StatsUI;

        private void Awake()
        {
            StateMachine.AddOnStateEnterListener(state =>
            {
                if (state == State.GameStart)
                {
                    var visitorUpdater = new PlayerStatsUpdater(StatsUI);
                    var player = CreatePlayer(visitorUpdater);
                    CreateWeapons(player, visitorUpdater);
                    StateMachine.AddGameplayUpdate(visitorUpdater);
                }

                if (state == State.GameEnd)
                {
                    InputBinder.ClearSubscriptions();
                }
            });
        }

        private GameObject CreatePlayer(IPlayerStatsVisitorUpdate visitorUpdate)
        {
            var player = Instantiate(PlayerConfig.PlayerPrefab, Vector3.zero, Quaternion.identity);

            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                var movePlayerInputListener = new MovePlayerInputListener(PlayerConfig, playerMovable);

                InputBinder.AddOnMoveListener(movePlayerInputListener.UpdateMoveInput);
                StateMachine.AddGameplayUpdate(movePlayerInputListener);

                visitorUpdate.AddAccepter(movePlayerInputListener);
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

        private void CreateWeapons(GameObject player, IPlayerStatsVisitorUpdate visitorUpdate)
        {
            if (player.TryGetComponent(out IInputMovable playerMovable))
            {
                CreateBulletSpawner(playerMovable);
                CreateLaserSpawner(playerMovable, visitorUpdate);
            }
        }

        private void CreateBulletSpawner(IInputMovable player)
        {
            var bulletLifeTimeChecker = new MortalLifeTimeChecker(0.1f);
            var bulletSpawner = new BulletSpawner(PlayerConfig, player, bulletLifeTimeChecker);
            InputBinder.AddOnFireListener(bulletSpawner.Spawn);
            StateMachine.AddGameplayUpdate(bulletLifeTimeChecker);
        }

        private void CreateLaserSpawner(IInputMovable player, IPlayerStatsVisitorUpdate visitorUpdate)
        {
            var laserLifeTimeChecker = new MortalLifeTimeChecker(0.02f);
            var laser = new LaserSpawner(PlayerConfig, player, laserLifeTimeChecker);
            InputBinder.AddOnLaserListener(laser.Spawn);
            StateMachine.AddGameplayUpdate(laserLifeTimeChecker);
            visitorUpdate.AddAccepter(laser);
        }
    }
}