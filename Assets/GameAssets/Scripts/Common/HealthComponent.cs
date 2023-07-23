using GameAssets.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace GameAssets.Scripts.Common
{
    public class HealthComponent : MonoBehaviour, IInitializable

    {
        [field: SerializeField] public int CurrentHealth { get; private set; }
        [SerializeField] private int maxHealth;
        [SerializeField] private bool useExternCall;
        [SerializeField] private UnityEvent onDieEvent;

        public virtual void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Kill();
            }
        }

        public virtual void Kill()
        {
            onDieEvent?.Invoke();
            if (useExternCall)
            {
                var iDies = GetComponents<IDie>();
                foreach (var iDie in iDies)
                {
                    iDie.OnDie();
                }
            }
        }

        public void Init(float value)
        {
            maxHealth = (int)value;
            CurrentHealth = maxHealth;
        }
    }
}