using Atomic.Contexts;

namespace Game.Scripts.PlayerContext
{
    public interface IPlayerContext : IContext{}
    
    public class PlayerContext :SceneContext, IPlayerContext
    {
      
    }
}