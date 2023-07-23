using System.Collections;
using GameAssets.Scripts.Common;
using GameAssets.Scripts.Fabrics;
using GameAssets.Scripts.GamePlaySystems;
using GameAssets.Scripts.Interfaces;
using GameAssets.Scripts.Main;
using UnityEngine;

namespace GameAssets.Scripts.Player
{
    public class PlayerAttack : MonoBehaviour, IConfigurable
    {
        [SerializeField] private BulletFabric bulletFabric;

        private Coroutine _attackWhile;
        private WaitForSeconds _timer;
        private CharacterComponent _currentTarget;
        private GameConfig _config;
        private void Attack()
        {
            if (!_currentTarget)
                return;
            var selfPosition = transform.position;
            bulletFabric.GetObject(new BulletFabricConfig(_config,
                _currentTarget.transform.position - selfPosition), selfPosition);
        }

        public bool TryAttack()
        {
            if (_attackWhile != null)
                return false;
            if (!_currentTarget)
            {
                _currentTarget = TargetFinder.GetNearestEnemyCharacter(transform.position, _config.PlayerAttackRange);
            }
                
            
            Attack();
            _attackWhile = StartCoroutine(AttackWhile());
            return true;
        }

        public void Configurate(GameConfig config)
        {
            _config = config;
            _timer = new WaitForSeconds(config.PlayerAttackCooldown);
        }

        private  IEnumerator AttackWhile()
        {
            yield return _timer;
            _attackWhile = null;
            yield break;
        }
    }
}