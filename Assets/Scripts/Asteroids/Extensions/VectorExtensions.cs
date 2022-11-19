using UnityEngine;

namespace Asteroids
{
    public static class VectorExtensions
    {
        public static float GetRandomInRange(this Vector2 range)
        {
            return Random.Range(range.x, range.y);
        }
    }
}