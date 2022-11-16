using UnityEngine;

namespace Asteroids.GameField
{
    public static class TelepotBackToScreen
    {
        public static void Teleport(Camera camera, GameObject toFix)
        {
            var screenPosition = camera.WorldToScreenPoint(toFix.transform.position);
            if (screenPosition.x < 0f)
                screenPosition.x = Screen.width;
            else if (screenPosition.x > Screen.width)
                screenPosition.x = 0f;

            if (screenPosition.y < 0f)
                screenPosition.y = Screen.height;
            else if (screenPosition.y > Screen.height)
                screenPosition.y = 0f;

            toFix.transform.position = camera.ScreenToWorldPoint(screenPosition);
        }
    }
}