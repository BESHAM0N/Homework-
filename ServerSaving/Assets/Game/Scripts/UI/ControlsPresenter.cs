using System;
using Game.Scripts.App;
using Game.Scripts.Observers;
using Zenject;

namespace Game.Gameplay
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly SaveGameObserver _saveObserver;
        private readonly LoadGameObserver _loadObserver;
        private readonly GameVersionManager _gameVersionManager;

        [Inject]
        public ControlsPresenter(SaveGameObserver saveObserver, LoadGameObserver loadObserver,
            GameVersionManager gameVersionManager)
        {
            _saveObserver = saveObserver;
            _loadObserver = loadObserver;
            _gameVersionManager = gameVersionManager;
        }

        public async void Save(Action<bool, int> callback)
        {
            var success = await _saveObserver.Save();
            var version = success ? _gameVersionManager.GetLastVersion() : -1;
            callback?.Invoke(success, version);
        }

        public async void Load(string versionText, Action<bool, int> callback)
        {
            if (!int.TryParse(versionText, out var version))
            {
                callback?.Invoke(false, -1);
                return;
            }

            var success = await _loadObserver.Load(version);
            callback?.Invoke(success, version);
        }
    }
}
