using UnityEngine;

namespace Asteroids.ObjectsFly
{
    public class SimpleFlyerComponent : MonoBehaviour, IFly
    {
        [SerializeField] private Transform ToFly;

        private Vector3 _flyVector;

        private void Update()
        {
            ToFly.Translate(_flyVector * Time.deltaTime, Space.World);
        }

        public void SetFlyVector(Vector3 flyVector)
        {
            _flyVector = flyVector;
        }
    }
}