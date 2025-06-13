using Atomic.Contexts;

namespace Game.PlayerContext
{
    public interface IPlayerContext : IContext{}
    
    public class PlayerContext :SceneContext, IPlayerContext
    {
      
    }
}