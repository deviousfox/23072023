using System;
using GameAssets.Scripts.Enemies;
using GameAssets.Scripts.Interfaces;
using GameAssets.Scripts.UI;
using UnityEngine;

namespace GameAssets.Scripts.Main
{
    public class GameRule : MonoBehaviour, IConfigurable 
    {
        [SerializeField] private EndScreenView endScreenView;
        private GameConfig _config;
        private int _maxEnemyCount;
        private int _currentEnemyCount;
        private bool _isPlayerDie;
        private void Awake()
        {
            Player.Player.OnPlayerDie += OnPlayerDie;
            Enemy.OnEnemyDie += OnEnemyDie;
        }

        public void OnEnemyDie(Enemy enemy)
        {
            if(_isPlayerDie)
                return;
            _currentEnemyCount++;
            if (_currentEnemyCount == _maxEnemyCount)
            {
                endScreenView.Show(true);
            }
        }
        public void OnPlayerDie()
        {
            _isPlayerDie = true;
            endScreenView.Show(false);
        }

        public void Configurate(GameConfig config)
        {
            _config = config;
            _maxEnemyCount = config.EnemyCount;
        }
    }
}