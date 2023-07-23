using System.Collections.Generic;
using GameAssets.Scripts.Common;
using GameAssets.Scripts.Enemies;
using GameAssets.Scripts.Interfaces;
using GameAssets.Scripts.Main;
using UnityEngine;


namespace GameAssets.Scripts.GamePlaySystems
{
    public class TargetFinder : MonoBehaviour, IConfigurable
    {
        public static List<Enemy> Enemies;

        public void Configurate(GameConfig config)
        {
            Enemies = new List<Enemy>(config.EnemyCount * 2);
            Enemy.OnEnemyDie += RemoveEnemy;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
        public static Enemy GetNearestEnemyCharacter(Vector2 selfPos, float range)
        {
            if (Enemies == null)
                return null;
            if (Enemies.Count == 0)
                return null;


            float distance = Mathf.Infinity;
            Vector2 position = selfPos;
            Enemy closestCharacter = null;
            foreach (var character in Enemies)
            {
                float curDistance = Vector2.Distance(character.transform.position, position);
                if (curDistance < distance)
                {
                    closestCharacter = character;
                    distance = curDistance;
                }
            }

            return closestCharacter;
        }
    }
}