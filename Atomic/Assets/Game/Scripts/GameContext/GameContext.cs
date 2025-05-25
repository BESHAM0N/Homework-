using Atomic.Contexts;

namespace Game.Scripts.GameContext
{
    public interface IGameContext : IContext{}
    
    public sealed class GameContext :  SingletonSceneContext<GameContext>, IGameContext
    {
        
    }
}