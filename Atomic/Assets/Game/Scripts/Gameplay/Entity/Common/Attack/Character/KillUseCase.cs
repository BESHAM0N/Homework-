using Atomic.Entities;
using Game.Context;
using SampleGame;

namespace Game.Gameplay
{
    public static class KillUseCase
    {
        public static void TryAddKill(IEntity victim, IGameContext gameContext)
        {
            if (!victim.HasEnemyTag())
                return;

            var player = gameContext.GetCharacter();
            if (player == null || !player.HasKill())
                return;
            
            player.GetKill().Value++;
        }
    }
}