using Atomic.Entities;
using Game.Gameplay;
using Modules.Gameplay;
using SampleGame;

namespace Game.Gameplay
{
    public static class WeaponUseCase
    {
        public static bool AddClips(in IEntity character, in int clips)
        {
            IWeaponEntity weapon = character.GetCurrentWeapon();
            if (weapon == null)
                return false;
        
            if (!weapon.TryGetAmmo(out Ammo ammo))
                return false;
        
            return ammo.Add(clips);
        }
    }
}