using UnityEngine;

namespace GameAssets.Scripts.Main
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "MenuName", order = 0)]
    public class GameConfig : ScriptableObject
    {
        public float PlayerAttackRange => playerAttackRange;
        public float PlayerAttackCooldown => playerAttackCooldown;
        public float PlayerBulletSpeed => playerBulletSpeed;
        public int PlayerDamage => playerDamage;

        public float MinEnemyMoveSpeed => minEnemyMoveSpeed;
        public float MaxEnemyMoveSpeed => maxEnemyMoveSpeed;
        public float MinEnemySpawnCooldown => minEnemySpawnCooldown;
        public float MaxEnemySpawnCooldown => maxEnemySpawnCooldown;
        public int EnemyCount { get; private set; }
        public int EnemyHealth => enemyHealth;

        public void ApplyData()
        {
            EnemyCount = Random.Range(minEnemyCount, maxEnemyCount+1);
        }
        [Header("Player")] 
        [SerializeField] private float playerAttackRange;
        [SerializeField] private float playerAttackCooldown;
        [SerializeField] private float playerBulletSpeed;
        [SerializeField] private int playerDamage;
        [Header("Enemies")] 
        [SerializeField] private float minEnemyMoveSpeed;
        [SerializeField] private float maxEnemyMoveSpeed;
        [SerializeField] private float minEnemySpawnCooldown;
        [SerializeField] private float maxEnemySpawnCooldown;
        [SerializeField] private int minEnemyCount;
        [SerializeField] private int maxEnemyCount;
        [SerializeField] private int enemyHealth;
    }
}