using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public sealed class EnemyController : MonoBehaviour
    {
        [Header("PositionPoints")]
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;

        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _container;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private BulletController _bulletController;

        private readonly HashSet<Enemy> _activeEnemies = new();
        private readonly Queue<Enemy> _enemyPool = new();
        private EnemyCreator _enemyCreator;

        private void Awake()
        {
            GeneratePool();
            _enemyCreator = new EnemyCreator(_enemyPrefab, _worldTransform, _container, _enemyPool);
        }

        private void GeneratePool()
        {
            for (var i = 0; i < 8; i++)
            {
                //никак не додумаю, как сделать этот инстатниет через _enemyCreator и передать ему заполненный пул
                Enemy enemy = Instantiate(_enemyPrefab, _container);
                _enemyPool.Enqueue(enemy);
                enemy.gameObject.SetActive(false);
            }
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 2));

                if (_activeEnemies.Count < 5)
                {
                    Transform spawnPosition = RandomPoint(_spawnPositions);
                    Transform attackPosition = RandomPoint(_attackPositions);
                    Enemy enemy = _enemyCreator.GetOrCreateEnemy(spawnPosition.position);
                    enemy.Activate(attackPosition.position);
                    enemy.OnFire += OnFire;

                    _activeEnemies.Add(enemy);
                }
            }
        }

        private void FixedUpdate()
        {
            foreach (Enemy enemy in _activeEnemies.ToArray())
            {
                if (enemy.Health <= 0)
                {
                    enemy.OnFire -= OnFire;
                    _enemyCreator.ReturnEnemy(enemy);
                    _activeEnemies.Remove(enemy);
                }
            }
        }

        private void OnFire(Vector2 position, Vector2 direction)
        {
            _bulletController.SpawnBullet(position, Color.red, (int)PhysicsLayer.ENEMY_BULLET, 1, false, direction * 2);
        }

        private Transform RandomPoint(Transform[] points)
        {
            int index = Random.Range(0, points.Length);
            return points[index];
        }
    }

}





