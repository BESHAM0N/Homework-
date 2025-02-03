using System;
using Game.Scripts.Factories;
using Game.Scripts.Observers;
using Zenject;

namespace Game.Scripts.Controllers
{
    public class EntitySpawnController : IInitializable, IDisposable
    {
        private readonly IEntityFactory _entityFactory;
        private readonly LoadGameObserver _loadGameObserver;

        public EntitySpawnController(IEntityFactory entityFactory, LoadGameObserver loadGameObserver)
        {
            _entityFactory  = entityFactory;
            _loadGameObserver = loadGameObserver;
        }
        
        public void Initialize()
        {
            _loadGameObserver.OnSpawnEntity += _entityFactory.CreateEntity;
        }

        public void Dispose()
        {
            _loadGameObserver.OnSpawnEntity -= _entityFactory.CreateEntity;
        }
    }
}