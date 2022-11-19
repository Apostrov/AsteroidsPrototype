using UnityEngine;

namespace Asteroids
{
    public static class ArrayExtensions
    {
        public static T GetRandomElement<T>(this T[] array)
        {
            if (array == null || array.Length < 1)
                return default;
            return array[Random.Range(0, array.Length)];
        }
    }
}