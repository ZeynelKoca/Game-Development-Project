using UnityEngine;

namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GamePausedState = false;

        public GameObject PauseMenuUI;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GamePausedState)
                {
                    // Pause menu is already active, so resume the game.
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        /// <summary>
        /// Resumes the game by un-freezing the game world and disabling the pause menu UI.
        /// </summary>
        public void Resume()
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePausedState = false;
        }

        /// <summary>
        /// Pauses the game by freezing the game world and enabling the pause menu UI.
        /// </summary>
        private void Pause()
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePausedState = true;
        }

        /// <summary>
        /// Quits the game.
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }
    }
}
