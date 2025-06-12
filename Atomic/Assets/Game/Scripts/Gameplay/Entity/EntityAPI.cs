/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using System;
using Atomic.Elements;
using Modules.Gameplay;
using Game.Gameplay;

namespace SampleGame
{
	public static class EntityAPI
	{
		///Tags
		public const int Damageable = 563499515;
		public const int Interactible = -2055148603;


		///Values
		public const int GameObject = 1482111001; // GameObject
		public const int Transform = -180157682; // Transform
		public const int Health = -915003867; // IReactiveVariable<int>
		public const int LifeTime = 1688468960; // Cooldown
		public const int DestroyAction = 85938956; // IAction
		public const int MoveSpeed = 526065662; // IReactiveVariable<float>
		public const int MoveCondition = 1466174948; // IExpression<bool>
		public const int MoveAction = 1225226561; // IAction<Vector3, float>
		public const int MoveDirection = -721923052; // IReactiveVariable<Vector3>
		public const int RotateDirection = -1044844011; // IReactiveVariable<Vector3>
		public const int RotateSpeed = -1838353354; // IValue<float>
		public const int RotateCondition = 1109699557; // IExpression<bool>
		public const int DamageEvent = -1472508891; // IEvent<int>
		public const int Damage = 375673178; // IValue<int>
		public const int Target = 1103309514; // IReactiveVariable<IEntity>
		public const int PistolWeapon = 1183190889; // IWeaponEntity
		public const int HandWeapon = 1077568457; // IWeaponEntity
		public const int BulletPrefab = -918778767; // SceneEntity
		public const int Kill = -1491338921; // IReactiveVariable<int>
		public const int Ammo = 1337839892; // Ammo
		public const int PickUpPrefab = 1763436596; // SceneEntity
		public const int FireCooldown = 695041130; // Cooldown
		public const int FirePoint = 397255013; // Transform
		public const int FireEvent = -1683597082; // IEvent
		public const int FireAction = 1186461126; // IAction
		public const int FireRequest = 1469079819; // IEvent
		public const int FireCondition = -280402907; // IFunction<bool>
		public const int FireRotateDirection = -252772034; // IReactiveVariable<Vector3>
		public const int Trigger = -707381567; // TriggerEventReceiver
		public const int Animator = -1714818978; // Animator
		public const int InteractAction = -1026843572; // IAction<IEntity>
		public const int TargetInteractible = 21081601; // IReactiveVariable<IEntity>


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractibleTag(this IEntity obj) => obj.HasTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractibleTag(this IEntity obj) => obj.AddTag(Interactible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractibleTag(this IEntity obj) => obj.DelTag(Interactible);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject GetGameObject(this IEntity obj) => obj.GetValue<GameObject>(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetGameObject(this IEntity obj, out GameObject value) => obj.TryGetValue(GameObject, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddGameObject(this IEntity obj, GameObject value) => obj.AddValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasGameObject(this IEntity obj) => obj.HasValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelGameObject(this IEntity obj) => obj.DelValue(GameObject);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetGameObject(this IEntity obj, GameObject value) => obj.SetValue(GameObject, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetHealth(this IEntity obj) => obj.GetValue<IReactiveVariable<int>>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifeTime(this IEntity obj) => obj.GetValue<Cooldown>(LifeTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifeTime(this IEntity obj, out Cooldown value) => obj.TryGetValue(LifeTime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLifeTime(this IEntity obj, Cooldown value) => obj.AddValue(LifeTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifeTime(this IEntity obj) => obj.HasValue(LifeTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifeTime(this IEntity obj) => obj.DelValue(LifeTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifeTime(this IEntity obj, Cooldown value) => obj.SetValue(LifeTime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity obj) => obj.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity obj, out IAction value) => obj.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDestroyAction(this IEntity obj, IAction value) => obj.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity obj) => obj.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity obj) => obj.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity obj, IAction value) => obj.SetValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<float> GetMoveSpeed(this IEntity obj) => obj.GetValue<IReactiveVariable<float>>(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveSpeed(this IEntity obj, out IReactiveVariable<float> value) => obj.TryGetValue(MoveSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.AddValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveSpeed(this IEntity obj) => obj.HasValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveSpeed(this IEntity obj) => obj.DelValue(MoveSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveSpeed(this IEntity obj, IReactiveVariable<float> value) => obj.SetValue(MoveSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetMoveCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(MoveCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveCondition(this IEntity obj) => obj.HasValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveCondition(this IEntity obj) => obj.DelValue(MoveCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(MoveCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<Vector3, float> GetMoveAction(this IEntity obj) => obj.GetValue<IAction<Vector3, float>>(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveAction(this IEntity obj, out IAction<Vector3, float> value) => obj.TryGetValue(MoveAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveAction(this IEntity obj, IAction<Vector3, float> value) => obj.AddValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveAction(this IEntity obj) => obj.HasValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveAction(this IEntity obj) => obj.DelValue(MoveAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveAction(this IEntity obj, IAction<Vector3, float> value) => obj.SetValue(MoveAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetMoveDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMoveDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(MoveDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMoveDirection(this IEntity obj) => obj.HasValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMoveDirection(this IEntity obj) => obj.DelValue(MoveDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMoveDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(MoveDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetRotateDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(RotateDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(RotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateDirection(this IEntity obj) => obj.HasValue(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateDirection(this IEntity obj) => obj.DelValue(RotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(RotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotateSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(RotateSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(RotateSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateSpeed(this IEntity obj) => obj.HasValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateSpeed(this IEntity obj) => obj.DelValue(RotateSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(RotateSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetRotateCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotateCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(RotateCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotateCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotateCondition(this IEntity obj) => obj.HasValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotateCondition(this IEntity obj) => obj.DelValue(RotateCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotateCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(RotateCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<int> GetDamageEvent(this IEntity obj) => obj.GetValue<IEvent<int>>(DamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageEvent(this IEntity obj, out IEvent<int> value) => obj.TryGetValue(DamageEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageEvent(this IEntity obj, IEvent<int> value) => obj.AddValue(DamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageEvent(this IEntity obj) => obj.HasValue(DamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageEvent(this IEntity obj) => obj.DelValue(DamageEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageEvent(this IEntity obj, IEvent<int> value) => obj.SetValue(DamageEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IEntity obj) => obj.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity obj, out IValue<int> value) => obj.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamage(this IEntity obj, IValue<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity obj, IValue<int> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetTarget(this IEntity obj) => obj.GetValue<IReactiveVariable<IEntity>>(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValue(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTarget(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IEntity obj) => obj.HasValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IEntity obj) => obj.DelValue(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IWeaponEntity GetPistolWeapon(this IEntity obj) => obj.GetValue<IWeaponEntity>(PistolWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPistolWeapon(this IEntity obj, out IWeaponEntity value) => obj.TryGetValue(PistolWeapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPistolWeapon(this IEntity obj, IWeaponEntity value) => obj.AddValue(PistolWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPistolWeapon(this IEntity obj) => obj.HasValue(PistolWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPistolWeapon(this IEntity obj) => obj.DelValue(PistolWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPistolWeapon(this IEntity obj, IWeaponEntity value) => obj.SetValue(PistolWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IWeaponEntity GetHandWeapon(this IEntity obj) => obj.GetValue<IWeaponEntity>(HandWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHandWeapon(this IEntity obj, out IWeaponEntity value) => obj.TryGetValue(HandWeapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHandWeapon(this IEntity obj, IWeaponEntity value) => obj.AddValue(HandWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHandWeapon(this IEntity obj) => obj.HasValue(HandWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHandWeapon(this IEntity obj) => obj.DelValue(HandWeapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHandWeapon(this IEntity obj, IWeaponEntity value) => obj.SetValue(HandWeapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetBulletPrefab(this IEntity obj) => obj.GetValue<SceneEntity>(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetBulletPrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(BulletPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddBulletPrefab(this IEntity obj, SceneEntity value) => obj.AddValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasBulletPrefab(this IEntity obj) => obj.HasValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelBulletPrefab(this IEntity obj) => obj.DelValue(BulletPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetBulletPrefab(this IEntity obj, SceneEntity value) => obj.SetValue(BulletPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<int> GetKill(this IEntity obj) => obj.GetValue<IReactiveVariable<int>>(Kill);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetKill(this IEntity obj, out IReactiveVariable<int> value) => obj.TryGetValue(Kill, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddKill(this IEntity obj, IReactiveVariable<int> value) => obj.AddValue(Kill, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasKill(this IEntity obj) => obj.HasValue(Kill);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelKill(this IEntity obj) => obj.DelValue(Kill);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetKill(this IEntity obj, IReactiveVariable<int> value) => obj.SetValue(Kill, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Ammo GetAmmo(this IEntity obj) => obj.GetValue<Ammo>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IEntity obj, out Ammo value) => obj.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmo(this IEntity obj, Ammo value) => obj.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IEntity obj) => obj.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IEntity obj) => obj.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IEntity obj, Ammo value) => obj.SetValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetPickUpPrefab(this IEntity obj) => obj.GetValue<SceneEntity>(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickUpPrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(PickUpPrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPickUpPrefab(this IEntity obj, SceneEntity value) => obj.AddValue(PickUpPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickUpPrefab(this IEntity obj) => obj.HasValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickUpPrefab(this IEntity obj) => obj.DelValue(PickUpPrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickUpPrefab(this IEntity obj, SceneEntity value) => obj.SetValue(PickUpPrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetFireCooldown(this IEntity obj) => obj.GetValue<Cooldown>(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCooldown(this IEntity obj, out Cooldown value) => obj.TryGetValue(FireCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireCooldown(this IEntity obj, Cooldown value) => obj.AddValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCooldown(this IEntity obj) => obj.HasValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCooldown(this IEntity obj) => obj.DelValue(FireCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCooldown(this IEntity obj, Cooldown value) => obj.SetValue(FireCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFirePoint(this IEntity obj) => obj.GetValue<Transform>(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePoint(this IEntity obj, out Transform value) => obj.TryGetValue(FirePoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFirePoint(this IEntity obj, Transform value) => obj.AddValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePoint(this IEntity obj, Transform value) => obj.SetValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireEvent(this IEntity obj) => obj.GetValue<IEvent>(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(FireEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireEvent(this IEntity obj, IEvent value) => obj.AddValue(FireEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireEvent(this IEntity obj) => obj.HasValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireEvent(this IEntity obj) => obj.DelValue(FireEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireEvent(this IEntity obj, IEvent value) => obj.SetValue(FireEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetFireAction(this IEntity obj) => obj.GetValue<IAction>(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireAction(this IEntity obj, out IAction value) => obj.TryGetValue(FireAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireAction(this IEntity obj, IAction value) => obj.AddValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireAction(this IEntity obj) => obj.HasValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireAction(this IEntity obj) => obj.DelValue(FireAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireAction(this IEntity obj, IAction value) => obj.SetValue(FireAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetFireRequest(this IEntity obj) => obj.GetValue<IEvent>(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRequest(this IEntity obj, out IEvent value) => obj.TryGetValue(FireRequest, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireRequest(this IEntity obj, IEvent value) => obj.AddValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRequest(this IEntity obj) => obj.HasValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRequest(this IEntity obj) => obj.DelValue(FireRequest);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRequest(this IEntity obj, IEvent value) => obj.SetValue(FireRequest, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IFunction<bool> GetFireCondition(this IEntity obj) => obj.GetValue<IFunction<bool>>(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireCondition(this IEntity obj, out IFunction<bool> value) => obj.TryGetValue(FireCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireCondition(this IEntity obj, IFunction<bool> value) => obj.AddValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireCondition(this IEntity obj) => obj.HasValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireCondition(this IEntity obj) => obj.DelValue(FireCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireCondition(this IEntity obj, IFunction<bool> value) => obj.SetValue(FireCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<Vector3> GetFireRotateDirection(this IEntity obj) => obj.GetValue<IReactiveVariable<Vector3>>(FireRotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFireRotateDirection(this IEntity obj, out IReactiveVariable<Vector3> value) => obj.TryGetValue(FireRotateDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFireRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.AddValue(FireRotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFireRotateDirection(this IEntity obj) => obj.HasValue(FireRotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFireRotateDirection(this IEntity obj) => obj.DelValue(FireRotateDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFireRotateDirection(this IEntity obj, IReactiveVariable<Vector3> value) => obj.SetValue(FireRotateDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTrigger(this IEntity obj) => obj.GetValue<TriggerEventReceiver>(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTrigger(this IEntity obj, out TriggerEventReceiver value) => obj.TryGetValue(Trigger, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTrigger(this IEntity obj, TriggerEventReceiver value) => obj.AddValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTrigger(this IEntity obj) => obj.HasValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTrigger(this IEntity obj) => obj.DelValue(Trigger);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTrigger(this IEntity obj, TriggerEventReceiver value) => obj.SetValue(Trigger, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IEntity> GetInteractAction(this IEntity obj) => obj.GetValue<IAction<IEntity>>(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetInteractAction(this IEntity obj, out IAction<IEntity> value) => obj.TryGetValue(InteractAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddInteractAction(this IEntity obj, IAction<IEntity> value) => obj.AddValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasInteractAction(this IEntity obj) => obj.HasValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelInteractAction(this IEntity obj) => obj.DelValue(InteractAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetInteractAction(this IEntity obj, IAction<IEntity> value) => obj.SetValue(InteractAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IReactiveVariable<IEntity> GetTargetInteractible(this IEntity obj) => obj.GetValue<IReactiveVariable<IEntity>>(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTargetInteractible(this IEntity obj, out IReactiveVariable<IEntity> value) => obj.TryGetValue(TargetInteractible, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTargetInteractible(this IEntity obj, IReactiveVariable<IEntity> value) => obj.AddValue(TargetInteractible, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTargetInteractible(this IEntity obj) => obj.HasValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTargetInteractible(this IEntity obj) => obj.DelValue(TargetInteractible);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTargetInteractible(this IEntity obj, IReactiveVariable<IEntity> value) => obj.SetValue(TargetInteractible, value);
    }
}
