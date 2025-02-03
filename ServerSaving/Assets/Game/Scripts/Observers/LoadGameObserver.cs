using Cysharp.Threading.Tasks;
using Modules.Entities;
using System;
using Game.Scripts.App.Server;
using Game.Scripts.Serialization;
using Zenject;

namespace Game.Scripts.Observers
{
    public class LoadGameObserver
    {
        public event Action<EntityData> OnSpawnEntity;
        public event Action OnDestroyEntities;
        
        private readonly IServerProxy serverProxy;
        private readonly IGameSerializer _gameSerializer;

        [Inject]
        public LoadGameObserver(IServerProxy serverProxy, IGameSerializer gameSerializer)
        {
            this.serverProxy = serverProxy;
            _gameSerializer = gameSerializer;
        }

        public async UniTask<bool> Load(int version)
        {
            var (success, json) = await serverProxy.LoadFromServer(version);
            
            if (!success || string.IsNullOrEmpty(json))
            {
                return false;
            }

            var entities = _gameSerializer.Deserialize(json);
            
            OnDestroyEntities?.Invoke();

            foreach (var data in entities)
            {
                OnSpawnEntity?.Invoke(data);
            }

            return true;
        }
    }
}