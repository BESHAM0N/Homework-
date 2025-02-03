using UnityEngine;

namespace Game.Scripts.App
{
    public sealed class GameVersionManager
    {
        private const string VERSION_KEY = "GameSaveVersion";
        public int GetLastVersion() => PlayerPrefs.GetInt(VERSION_KEY, 0);

        public void SaveVersion(int version)
        {
            PlayerPrefs.SetInt(VERSION_KEY, version);
            PlayerPrefs.Save();
        }
    }
}