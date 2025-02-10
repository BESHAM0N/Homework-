using System;
using Game.Scripts.Observers;
using Zenject;

namespace Game.Gameplay
{
    public sealed class ControlsPresenter : IControlsPresenter
    {
        private readonly GameSaveLoader _gameSaveLoader;

        [Inject]
        public ControlsPresenter(GameSaveLoader gameSaveLoader)
        {
            _gameSaveLoader = gameSaveLoader;
        }

        public async void Save(Action<bool, int> callback)
        {
            var result = await _gameSaveLoader.Save();
            callback?.Invoke(result.Success, result.Version);
        }

        public async void Load(string versionText, Action<bool, int> callback)
        {
            if (!int.TryParse(versionText, out var version))
            {
                callback?.Invoke(false, -1);
                return;
            }

            var success = await _gameSaveLoader.Load(version);
            callback?.Invoke(success, version);
        }
    }
}
