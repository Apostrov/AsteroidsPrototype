using UnityEngine;

namespace Asteroids.Enemy.MoveToTarget
{
    public interface ITarget
    {
        Transform GetTarget();
    }
}