using Cysharp.Threading.Tasks;
using Game.Scripts.App.Server;
using Game.Scripts.Serialization;
using Zenject;

namespace Game.Scripts.Observers
{
    public class GameSaveLoader
    {
        private readonly IGameRepository _gameRepository;
        private readonly EntityWorldSerializer _entityWorldSerializer;

        [Inject]
        public GameSaveLoader(IGameRepository gameRepository, EntityWorldSerializer entityWorldSerializer)
        {
            _gameRepository = gameRepository;
            _entityWorldSerializer = entityWorldSerializer;
        }
      
        public async UniTask<SaveResult> Save()
        {
            var gameState = _entityWorldSerializer.Serialize();
            return await _gameRepository.Save(gameState);
        }
      
        public async UniTask<bool> Load(int version)
        {
            var saveResult = await _gameRepository.Load(version);
            
            if (!saveResult.Success || string.IsNullOrEmpty(saveResult.Data))
            {
                return false;
            }

            _entityWorldSerializer.Deserialize(saveResult.Data);
            return true;
        }
    }
}