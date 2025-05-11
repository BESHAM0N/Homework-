using Atomic.Entities;

namespace Game.Gameplay
{
    public interface IWeaponEntity : IEntity
    {
        
    }
    
    public sealed class WeaponEntity : SceneEntity, IWeaponEntity
    {
        
    }
}