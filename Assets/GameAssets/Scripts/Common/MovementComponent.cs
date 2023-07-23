using System;
using GameAssets.Scripts.Interfaces;
using UnityEngine;

namespace GameAssets.Scripts.Common
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour, IInitializable
    {
        [SerializeField] private protected Rigidbody2D rb;
        [SerializeField] private protected float moveSpeed;

        
        public void MoveDirection(Vector3 direction)
        {
            rb.MovePosition(transform.position+direction.normalized*(moveSpeed*Time.deltaTime));
        }

        public void Init(float value)
        {
            moveSpeed = Mathf.Abs(value);
        }
    }
}