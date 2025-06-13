using Atomic.Entities;
using Game.Context;
using SampleGame;

namespace Game.Gameplay
{
    public static class KillUseCase
    {
        public static void TryAddKill(IEntity victim)
        {
            if (!victim.HasEnemyTag())
                return;

            var player = PlayersUseCase.GetCharacter(Context.GameContext.Instance, 1);
            if (player == null || !player.HasKill())
                return;
            
            player.GetKill().Value++;
        }
    }
}