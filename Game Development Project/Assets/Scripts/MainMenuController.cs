using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
        public AudioSource Source;
        private bool _introPlayed;
        /// <summary>
        /// Starts the first game play related scene.
        /// </summary>
        public void StartGame()
        {
            if (_introPlayed)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                SceneManager.LoadScene("IntroScene");
                _introPlayed = true;
            }
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
