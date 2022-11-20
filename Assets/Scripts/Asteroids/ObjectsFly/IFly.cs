using UnityEngine;

namespace Asteroids.ObjectsFly
{
    public interface IFly
    {
        void SetFlyVector(Vector3 flyVector);
        Vector3 GetPosition();
    }
}