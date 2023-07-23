using UnityEngine;

namespace GameAssets.Scripts.Common
{
    public class CharacterComponent : MonoBehaviour
    {
        public HealthComponent HealthComponent => healthComponent;
        public MovementComponent MovementComponent => movementComponent;

        [SerializeField] private protected HealthComponent healthComponent;
        [SerializeField] private protected MovementComponent movementComponent;
    }
}