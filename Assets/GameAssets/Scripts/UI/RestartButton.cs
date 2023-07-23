using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts.UI
{
    public class RestartButton : MonoBehaviour
    {
        public void Restart()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
    }
}