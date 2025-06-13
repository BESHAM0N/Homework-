using Atomic.Contexts;

namespace Game.Context
{
    public interface IGameContext : IContext{}
    
    public sealed class GameContext :  SingletonSceneContext<GameContext>, IGameContext
    {
        
    }
}