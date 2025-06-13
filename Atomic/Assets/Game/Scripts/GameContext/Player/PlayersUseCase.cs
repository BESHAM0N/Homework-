using System.Collections.Generic;
using Atomic.Entities;
using Game.PlayerContext;
using SampleGame;
using UnityEngine;

namespace Game.Context
{
    public static class PlayersUseCase
    {
        public static IEntity GetCharacter(in IGameContext gameContext, in int player)
        {
            IDictionary<int, IPlayerContext> players = gameContext.GetPlayers();
            
            if (!players.ContainsKey(player) || players[player] == null)
                Debug.LogError($"Player with id {player} not found or null.");
            
            IPlayerContext context = players[player];
            return context.GetCharacter();
        }
    }
}