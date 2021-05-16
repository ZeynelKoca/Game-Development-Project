using System;
using System.Collections;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.MiniGames.Cake
{
    public class CakeManager : MonoBehaviour
    {
        public Ingredient[] Ingredients;
        public ParticleSystem ParticleSystem;
        public AudioSource CorrectSfx;
        public AudioSource WrongSfx;

        public UiController UiController;

        private int _currentCakeStep;
        private const int TotalCakeSteps = 9;

        void Awake()
        {
            // TODO: Add voice over audio and change # seconds according to the audio duration.
            SubscribeToExternalEvents();
            StartCoroutine(UiController.DisableMiniGameFor(4f));

            // Initializes the sfx volume
            UpdateSfxVolume(null, null);
        }

        /// <summary>
        /// Subscribes to external events.
        /// </summary>
        private void SubscribeToExternalEvents()
        {
            Settings.OnVolumeChanged += UpdateSfxVolume;
        }

        /// <summary>
        /// Unsubscribes from external events.
        /// </summary>
        private void UnsubscribeFromExternalEvents()
        {
            Settings.OnVolumeChanged -= UpdateSfxVolume;
        }

        /// <summary>
        /// Updates the volume of the sound effects in the mini game
        /// according to the player's volume setting.
        /// </summary>
        private void UpdateSfxVolume(object sender, EventArgs e)
        {
            CorrectSfx.volume = Settings.VolumeSetting;
            WrongSfx.volume = Settings.VolumeSetting;
        }

        /// <summary>
        /// Handles the OnClick event whenever an ingredient button is clicked
        /// in the UI to check whether the right ingredient is pressed or not.
        /// </summary>
        /// <param name="ingredientComponent">The ingredient type of the pressed button.</param>
        public void OnIngredientClick(IngredientComponent ingredientComponent)
        {
            if (ingredientComponent.Ingredient == Ingredients[_currentCakeStep])
            {
                // Correct ingredient has been clicked.
                _currentCakeStep++;
                StartCoroutine(PlayCorrectIngredientFx());
                if (IsMiniGameFinished())
                {
                    CloseMiniGame();
                    return;
                }

                StartCoroutine(UiController.SetSpeechBubbleText(_currentCakeStep));
            }
            else
            {
                // Wrong ingredient has been clicked.
                WrongSfx.Play();
            }
        }

        /// <summary>
        /// Shuts down all playable components of the mini game
        /// and rewards the player with an achievement.
        /// </summary>
        private void CloseMiniGame()
        {
            StartCoroutine(UiController.MiniGameFinished(2f));
            AssignAchievement();
            UnsubscribeFromExternalEvents();
        }

        /// <summary>
        /// Assigns the achievement for completing the
        /// quest of current NPC to the player.
        /// </summary>
        private void AssignAchievement()
        {
            if (!AchievementsManager.Instance.CrocodileAchieved)
            {
                AchievementsManager.Instance.CrocodileAchieved = true;
            }
        }

        /// <summary>
        /// Checks whether the mini game is finished by comparing
        /// the current recipe's step with the total amount of steps.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the mini game is finished, <c>false</c> otherwise.
        /// </returns>
        private bool IsMiniGameFinished()
        {
            return _currentCakeStep == TotalCakeSteps;
        }

        /// <summary>
        /// Plays the correct ingredient sound and particle effect.
        /// </summary>
        private IEnumerator PlayCorrectIngredientFx()
        {
            CorrectSfx.Play();
            yield return new WaitForSeconds(0.15f);
            ParticleSystem.Play();
        }

        /// <summary>
        /// Loads the village scene.
        /// </summary>
        public void NavigateVillageScene()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
