using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        /// <summary>
        /// Starts the first game play related scene.
        /// </summary>
        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
