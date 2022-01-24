using UnityEngine;

namespace Utils
{
    public static class GamePauser
    {
        public static void Pause()
        {
            Time.timeScale = 0f;
        }
        public static void UnPause()
        {
            Time.timeScale = 1f;
        }
    }
}