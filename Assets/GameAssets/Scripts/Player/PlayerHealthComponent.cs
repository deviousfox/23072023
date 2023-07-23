using System;
using GameAssets.Scripts.Common;

namespace GameAssets.Scripts.Player
{
    public class PlayerHealthComponent: HealthComponent
    {
        public static Action<int> OnPlayerHit;

        private void Start()
        {
            OnPlayerHit?.Invoke(CurrentHealth);
        }

        public override void ApplyDamage(int damage)
        {
            base.ApplyDamage(damage);
            OnPlayerHit?.Invoke(CurrentHealth);
        }

        public override void Kill()
        {
            base.Kill();
        }
    }
}