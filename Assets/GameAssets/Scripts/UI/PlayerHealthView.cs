using System;
using GameAssets.Scripts.Player;
using TMPro;
using UnityEngine;

namespace GameAssets.Scripts.UI
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;

        private void Awake()
        {
            PlayerHealthComponent.OnPlayerHit += UpdateValue;
        }

        public void UpdateValue(int value)
        {
            healthText.text = $"Health: {value}";
        }
    }
}