/**
* Code generation. Don't modify! 
**/

using Atomic.Contexts;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Contexts;
using Atomic.Entities;
using Atomic.Elements;
using System.Collections.Generic;
using Game.PlayerContext;
using Modules.Common;

namespace SampleGame
{
	public static class PlayerContextAPI
	{


		///Values
		public const int Health = -915003867; // int
		public const int Speed = -823668238; // float
		public const int Transform = -180157682; // Transform
		public const int Character = 294335127; // IEntity
		public const int MoveJoystick = -1686028204; // Joystick
		public const int AttackJoystick = 1168591300; // Joystick


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetHealth(this IPlayerContext obj) => obj.GetValue<int>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IPlayerContext obj, out int value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IPlayerContext obj, int value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IPlayerContext obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IPlayerContext obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IPlayerContext obj, int value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetSpeed(this IPlayerContext obj) => obj.GetValue<float>(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpeed(this IPlayerContext obj, out float value) => obj.TryGetValue(Speed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddSpeed(this IPlayerContext obj, float value) => obj.AddValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpeed(this IPlayerContext obj) => obj.HasValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpeed(this IPlayerContext obj) => obj.DelValue(Speed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpeed(this IPlayerContext obj, float value) => obj.SetValue(Speed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IPlayerContext obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IPlayerContext obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IPlayerContext obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IPlayerContext obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IPlayerContext obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IPlayerContext obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetCharacter(this IPlayerContext obj) => obj.GetValue<IEntity>(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IPlayerContext obj, out IEntity value) => obj.TryGetValue(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCharacter(this IPlayerContext obj, IEntity value) => obj.AddValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IPlayerContext obj) => obj.HasValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IPlayerContext obj) => obj.DelValue(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IPlayerContext obj, IEntity value) => obj.SetValue(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetMoveJoystick(this IPlayerContext obj) => obj.GetValue<Joystick>(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveJoystick(this IPlayerContext obj, out Joystick value) => obj.TryGetValue(MoveJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveJoystick(this IPlayerContext obj, Joystick value) => obj.AddValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveJoystick(this IPlayerContext obj) => obj.HasValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveJoystick(this IPlayerContext obj) => obj.DelValue(MoveJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveJoystick(this IPlayerContext obj, Joystick value) => obj.SetValue(MoveJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Joystick GetAttackJoystick(this IPlayerContext obj) => obj.GetValue<Joystick>(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackJoystick(this IPlayerContext obj, out Joystick value) => obj.TryGetValue(AttackJoystick, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackJoystick(this IPlayerContext obj, Joystick value) => obj.AddValue(AttackJoystick, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackJoystick(this IPlayerContext obj) => obj.HasValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackJoystick(this IPlayerContext obj) => obj.DelValue(AttackJoystick);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackJoystick(this IPlayerContext obj, Joystick value) => obj.SetValue(AttackJoystick, value);
    }
}
