using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
