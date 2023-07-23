
using System;
using GameAssets.Scripts.Common;
using GameAssets.Scripts.Interfaces;
using UnityEngine;

namespace GameAssets.Scripts.Player
{
    public class Player: CharacterComponent, IDie
    {
        public static Action OnPlayerDie;
        [SerializeField] private PlayerAttack attackComponent;
        private Vector3 _moveDirection;
        private CharacterComponent _currentTarget;
        private void Update()
        {
            _moveDirection.x = Input.GetAxis("Horizontal");
            _moveDirection.y = Input.GetAxis("Vertical");
            
            movementComponent.MoveDirection(_moveDirection);
            attackComponent.TryAttack();
        }


        public void OnDie()
        {
            OnPlayerDie?.Invoke();
        }
    }
}