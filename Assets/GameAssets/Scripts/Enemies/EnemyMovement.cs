using System;
using System.Collections;
using GameAssets.Scripts.Common;
using UnityEngine;

namespace GameAssets.Scripts.Enemies
{
    public class EnemyMovement : MovementComponent
    {
        private Vector3 _direction;
        private Coroutine _directionMovementRoutine;

        public void MoveInstantDirection(Vector3 direction)
        {
            _direction = direction;
            if(_directionMovementRoutine != null)
                StopCoroutine(_directionMovementRoutine);
            _directionMovementRoutine =StartCoroutine(DirectionMovement());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator DirectionMovement()
        {
            while (true)
            {
                rb.MovePosition(transform.position + _direction*(moveSpeed* Time.deltaTime));
                yield return new WaitForEndOfFrame();
            }
        }
    }
}