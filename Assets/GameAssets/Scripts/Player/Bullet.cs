using System;
using System.Collections;
using GameAssets.Scripts.Common;
using GameAssets.Scripts.Fabrics;
using GameAssets.Scripts.Interfaces;
using UnityEngine;

namespace GameAssets.Scripts.Player
{
    public class Bullet : MonoBehaviour, IFabricConfigurable
    {
        [SerializeField] private Rigidbody2D rb;
        private int _damage;

        public void Configurate(FabricConfig config)
        {
            
            var conf = (BulletFabricConfig)config;
            _damage = conf.Damage;
            rb.AddForce(conf.Direcion.normalized * conf.Velocity, ForceMode2D.Impulse);
            transform.up = conf.Direcion;
            StartCoroutine(SelfDestroy());
        }

        private IEnumerator SelfDestroy()
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.ApplyDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}