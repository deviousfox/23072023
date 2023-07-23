using System;
using GameAssets.Scripts.Enemies;
using UnityEngine;
using UnityEngine.Events;

namespace GameAssets.Scripts.Common
{
    public class DeadArea : MonoBehaviour
    {
        [SerializeField]private UnityEvent<int> onHit;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                onHit?.Invoke(1);
                enemy.OnDie();
            }
        }
    }
}