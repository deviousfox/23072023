using System.Collections;
using GameAssets.Scripts.Fabrics;
using GameAssets.Scripts.Interfaces;
using GameAssets.Scripts.Main;
using UnityEngine;

namespace GameAssets.Scripts.GamePlaySystems
{
    public class EnemySpawner : MonoBehaviour, IConfigurable
    {
        [SerializeField] private Transform[] spawns;
        [SerializeField] private EnemyFabric enemyFabric;
        private float _minSpawnCooldown, _maxSpawnCooldown;
        private int _maxEnemyCount;
        private int _currentEnemyCount;
        private Coroutine _spawnRoutine;
        private GameConfig _config;

        public void Configurate(GameConfig config)
        {
            _config = config;
            _minSpawnCooldown = config.MinEnemySpawnCooldown;
            _maxSpawnCooldown = config.MaxEnemySpawnCooldown;
            _maxEnemyCount = config.EnemyCount;
            Spawn();
        }

        public void Spawn()
        {
            if (_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
            if (_currentEnemyCount < _maxEnemyCount)
                _spawnRoutine = StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnCooldown, _maxSpawnCooldown));
            var enemyConfig = new EnemyFabricConfig(_config);
            enemyFabric.GetObject<EnemyFabricConfig>(enemyConfig, spawns[Random.Range(0, spawns.Length)].position);
            _currentEnemyCount++;
            Spawn();
        }
    }
}