using UnityEngine;

namespace Asteroids
{
    public static class GameObjectExtension
    {
        public static bool TryGetComponentInChildren<T>(this GameObject toGet, out T element)
        {
            element = default;
            if (toGet == null)
                return false;

            var component = toGet.GetComponentInChildren<T>();
            if (component == null) 
                return false;
            
            element = component;
            return true;

        }
    }
}