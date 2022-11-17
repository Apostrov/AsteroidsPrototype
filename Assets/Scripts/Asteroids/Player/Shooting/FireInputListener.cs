namespace Asteroids.Player.Shooting
{
    public class FireInputListener
    {
        private readonly BulletSpawner _bulletSpawner;
        public FireInputListener(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }

        public void GetFireSignal()
        {
            _bulletSpawner.Spawn();
        }
    }
}