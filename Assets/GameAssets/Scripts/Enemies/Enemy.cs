using System;
using GameAssets.Scripts.Common;
using GameAssets.Scripts.Fabrics;
using GameAssets.Scripts.GamePlaySystems;
using GameAssets.Scripts.Interfaces;
using UnityEngine;

namespace GameAssets.Scripts.Enemies
{
    public class Enemy : CharacterComponent, IDie, IFabricConfigurable
    {
        public static Action<Enemy> OnEnemyDie;

        public void Init(int maxHealth, float moveSpeed)
        {
            healthComponent.Init(maxHealth);
            movementComponent.Init(moveSpeed);
            var movement = (EnemyMovement)movementComponent;
            movement.MoveInstantDirection(Vector3.down);
            TargetFinder.Enemies.Add(this);
        }


        public void OnDie()
        {
            OnEnemyDie?.Invoke(this);
            Destroy(gameObject);
        }

        public void Configurate(FabricConfig config)
        {
            var conf = (EnemyFabricConfig)config;
            Init(conf.Health, conf.MoveSpeed);
        }
    }
}