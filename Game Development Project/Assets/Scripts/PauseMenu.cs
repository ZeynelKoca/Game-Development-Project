using Assets.Scripts.Npc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GamePausedState;

        public GameObject PauseMenuUI;

        // Start is called before the first frame update
        void Start()
        {
            SetPauseState(false);
        }

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
        /// Sets the paused state of the game.
        /// </summary>
        /// <param name="isGamePaused">The pause state which the game should be set to.</param>
        private void SetPauseState(bool isGamePaused)
        {
            PauseMenuUI.SetActive(isGamePaused);
            // Freezes the game time according to the paused state.
            if (isGamePaused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                if (!InteractableObject.IsDialogShowing)
                {
                    Time.timeScale = 1f;
                }
            }
            GamePausedState = isGamePaused;

            Cursor.visible = isGamePaused;
            // Unlocks the cursor according to the paused state in order to navigate the pause menu.
            Cursor.lockState = isGamePaused ? CursorLockMode.None : CursorLockMode.Locked;
        }

        /// <summary>
        /// Resumes the game by un-freezing the game world and disabling the pause menu UI.
        /// </summary>
        public void Resume()
        {
            SetPauseState(false);
        }

        /// <summary>
        /// Pauses the game by freezing the game world and enabling the pause menu UI.
        /// </summary>
        private void Pause()
        {
            SetPauseState(true);
        }

        /// <summary>
        /// Quits the game.
        /// </summary>
        public void Quit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Loads the Main Menu scene.
        /// </summary>
        public void NavigateMainMenu()
        {
            SetPauseState(false);

            InteractableObject.IsDialogShowing = false;
            // Game is not in paused state when in the main menu, but you still want to be able to use the Cursor.
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
