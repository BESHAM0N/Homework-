using Leopotam.EcsLite;

namespace Client.Entities.Core.TakeDamage
{
    public struct TakeDamageEvent
    {
        public EcsPackedEntity source;
        public EcsPackedEntity target;
        public int damage;
    }
}