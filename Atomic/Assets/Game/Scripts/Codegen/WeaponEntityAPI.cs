/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Game.Gameplay;

namespace SampleGame
{
	public static class WeaponEntityAPI
	{


		///Values
		public const int BulletPrefab = -918778767; // SceneEntity
		public const int FirePoint = 397255013; // Transform
		public const int HitRadius = -640536362; // float
		public const int Ammo = 1337839892; // int


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetBulletPrefab(this IWeaponEntity obj) => obj.GetValue<SceneEntity>(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPrefab(this IWeaponEntity obj, out SceneEntity value) => obj.TryGetValue(BulletPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletPrefab(this IWeaponEntity obj, SceneEntity value) => obj.AddValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPrefab(this IWeaponEntity obj) => obj.HasValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPrefab(this IWeaponEntity obj) => obj.DelValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPrefab(this IWeaponEntity obj, SceneEntity value) => obj.SetValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFirePoint(this IWeaponEntity obj) => obj.GetValue<Transform>(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePoint(this IWeaponEntity obj, out Transform value) => obj.TryGetValue(FirePoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFirePoint(this IWeaponEntity obj, Transform value) => obj.AddValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePoint(this IWeaponEntity obj) => obj.HasValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePoint(this IWeaponEntity obj) => obj.DelValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePoint(this IWeaponEntity obj, Transform value) => obj.SetValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetHitRadius(this IWeaponEntity obj) => obj.GetValue<float>(HitRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHitRadius(this IWeaponEntity obj, out float value) => obj.TryGetValue(HitRadius, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHitRadius(this IWeaponEntity obj, float value) => obj.AddValue(HitRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHitRadius(this IWeaponEntity obj) => obj.HasValue(HitRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHitRadius(this IWeaponEntity obj) => obj.DelValue(HitRadius);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHitRadius(this IWeaponEntity obj, float value) => obj.SetValue(HitRadius, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetAmmo(this IWeaponEntity obj) => obj.GetValue<int>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IWeaponEntity obj, out int value) => obj.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmo(this IWeaponEntity obj, int value) => obj.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IWeaponEntity obj) => obj.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IWeaponEntity obj) => obj.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IWeaponEntity obj, int value) => obj.SetValue(Ammo, value);
    }
}
