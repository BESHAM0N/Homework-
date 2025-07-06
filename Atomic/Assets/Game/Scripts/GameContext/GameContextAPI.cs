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
using System.Collections.Generic;
using Modules.Common;

namespace SampleGame
{
	public static class GameContextAPI
	{


		///Values
		public const int BulletPool = 1915726678; // IEntityPool
		public const int Character = 294335127; // IEntity
		public const int Health = -915003867; // int
		public const int Speed = -823668238; // float
		public const int Transform = -180157682; // Transform
		public const int MoveJoystick = -1686028204; // Joystick
		public const int AttackJoystick = 1168591300; // Joystick


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
		public static IEntity GetCharacter(this IGameContext obj) => obj.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IGameContext obj, out IEntity value) => obj.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacter(this IGameContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IGameContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IGameContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IGameContext obj, IEntity value) => obj.SetValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetHealth(this IGameContext obj) => obj.GetValue<int>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IGameContext obj, out int value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IGameContext obj, int value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IGameContext obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IGameContext obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IGameContext obj, int value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetSpeed(this IGameContext obj) => obj.GetValue<float>(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpeed(this IGameContext obj, out float value) => obj.TryGetValue(Speed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddSpeed(this IGameContext obj, float value) => obj.AddValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpeed(this IGameContext obj) => obj.HasValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpeed(this IGameContext obj) => obj.DelValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpeed(this IGameContext obj, float value) => obj.SetValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IGameContext obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IGameContext obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IGameContext obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IGameContext obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IGameContext obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IGameContext obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetMoveJoystick(this IGameContext obj) => obj.GetValue<Joystick>(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveJoystick(this IGameContext obj, out Joystick value) => obj.TryGetValue(MoveJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveJoystick(this IGameContext obj, Joystick value) => obj.AddValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveJoystick(this IGameContext obj) => obj.HasValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveJoystick(this IGameContext obj) => obj.DelValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveJoystick(this IGameContext obj, Joystick value) => obj.SetValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetAttackJoystick(this IGameContext obj) => obj.GetValue<Joystick>(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackJoystick(this IGameContext obj, out Joystick value) => obj.TryGetValue(AttackJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackJoystick(this IGameContext obj, Joystick value) => obj.AddValue(AttackJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackJoystick(this IGameContext obj) => obj.HasValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackJoystick(this IGameContext obj) => obj.DelValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackJoystick(this IGameContext obj, Joystick value) => obj.SetValue(AttackJoystick, value);
    }
}
