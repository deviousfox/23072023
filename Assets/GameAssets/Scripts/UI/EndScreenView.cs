using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.UI
{
    public class EndScreenView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private Image bg;
        [SerializeField] private Image content;
        public void Show(bool isWin)
        {
            bg.enabled = true;
            content.gameObject.SetActive(true);
            winText.text = isWin ? "Победа" : "Поражение";
        }
    }
}