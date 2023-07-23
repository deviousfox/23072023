using GameAssets.Scripts.Enemies;
using GameAssets.Scripts.Main;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameAssets.Scripts.Fabrics
{
    public class EnemyFabric : GenericFabric<Enemy>
    {
        public override Enemy GetObject<TFabricConfig>(TFabricConfig config,Vector3 pos)
        {
            var enemy = Instantiate(prefab, pos, quaternion.identity);
            enemy.Configurate(config);
            return enemy;
        }
    }

    public class EnemyFabricConfig: FabricConfig
    {
        public float MoveSpeed => Random.Range(minSpeed, maxSpeed);
        private float minSpeed;
        private float maxSpeed;
        public int Health { get; private set; }

        public EnemyFabricConfig(GameConfig config)
        {
            minSpeed = config.MinEnemyMoveSpeed;
            maxSpeed = config.MaxEnemyMoveSpeed;
            Health = config.EnemyHealth;
        }
    }
}