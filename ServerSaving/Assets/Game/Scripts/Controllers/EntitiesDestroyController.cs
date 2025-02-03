using System;
using Game.Scripts.App;
using Game.Scripts.Observers;
using Zenject;
using Modules.Entities;

namespace Game.Scripts.Controllers
{
    public sealed class EntitiesDestroyController : IInitializable, IDisposable
    {
        private readonly EntityWorld _entityWorld;
        private readonly LoadGameObserver _loadGameObserver;

        public EntitiesDestroyController(EntityWorld entityWorld, LoadGameObserver loadGameObserver)
        {
            _entityWorld  = entityWorld;
            _loadGameObserver = loadGameObserver;
        }
        
        public void Initialize()
        {
            _loadGameObserver.OnDestroyEntities += _entityWorld.DestroyAll;
        }

        public void Dispose()
        {
            _loadGameObserver.OnDestroyEntities -= _entityWorld.DestroyAll;
        }
    }
}