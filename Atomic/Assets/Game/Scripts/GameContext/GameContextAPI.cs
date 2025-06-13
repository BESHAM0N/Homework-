/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Contexts;
using Atomic.Entities;
using Atomic.Elements;
using Game.Context;
using Game.PlayerContext;
using System.Collections.Generic;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int BulletPool = 1915726678; // IEntityPool
		public const int Player = -1615495341; // IPlayerContext
		public const int Players = -369919430; // IDictionary<int, IPlayerContext>


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntityPool GetBulletPool(this IGameContext obj) => obj.GetValue<IEntityPool>(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPool(this IGameContext obj, out IEntityPool value) => obj.TryGetValue(BulletPool, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletPool(this IGameContext obj, IEntityPool value) => obj.AddValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPool(this IGameContext obj) => obj.HasValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPool(this IGameContext obj) => obj.DelValue(BulletPool);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPool(this IGameContext obj, IEntityPool value) => obj.SetValue(BulletPool, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IPlayerContext GetPlayer(this IGameContext obj) => obj.GetValue<IPlayerContext>(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayer(this IGameContext obj, out IPlayerContext value) => obj.TryGetValue(Player, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayer(this IGameContext obj, IPlayerContext value) => obj.AddValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayer(this IGameContext obj) => obj.HasValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayer(this IGameContext obj) => obj.DelValue(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayer(this IGameContext obj, IPlayerContext value) => obj.SetValue(Player, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IDictionary<int, IPlayerContext> GetPlayers(this IGameContext obj) => obj.GetValue<IDictionary<int, IPlayerContext>>(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPlayers(this IGameContext obj, out IDictionary<int, IPlayerContext> value) => obj.TryGetValue(Players, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayers(this IGameContext obj, IDictionary<int, IPlayerContext> value) => obj.AddValue(Players, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayers(this IGameContext obj) => obj.HasValue(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayers(this IGameContext obj) => obj.DelValue(Players);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPlayers(this IGameContext obj, IDictionary<int, IPlayerContext> value) => obj.SetValue(Players, value);
    }
}
