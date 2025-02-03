using Cysharp.Threading.Tasks;
using Game.Scripts.App;
using Game.Scripts.App.Server;
using Game.Scripts.Serialization;
using Modules.Entities;
using Zenject;

namespace Game.Scripts.Observers
{
    public class SaveGameObserver
    {
        private readonly EntityWorld _entityWorld;
        private readonly IServerProxy serverProxy;
        private readonly IGameSerializer _gameSerializer;
        private readonly GameVersionManager _gameVersionManager;

        [Inject]
        public SaveGameObserver(EntityWorld entityWorld, IServerProxy serverProxy, IGameSerializer gameSerializer, GameVersionManager gameVersionManager)
        {
            _entityWorld = entityWorld;
            this.serverProxy = serverProxy;
            _gameSerializer = gameSerializer;
            _gameVersionManager = gameVersionManager;
        }

        public async UniTask<bool> Save()
        {
            var version = _gameVersionManager.GetLastVersion() + 1;
            var gameState = _gameSerializer.Serialize(_entityWorld.GetAll());

            var success = await serverProxy.SaveToServer(version, gameState);
            if (success)
            {
                _gameVersionManager.SaveVersion(version);
            }

            return success;
        }
    }
}