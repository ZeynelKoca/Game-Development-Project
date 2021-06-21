using System;
using System.Collections;
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
        public NpcAnimationController NpcAnimationController;

        private const int TotalCakeSteps = 9;
        private int _currentCakeStep;

        void Awake()
        {
            SubscribeToExternalEvents();
            StartCoroutine(UiController.DisableMiniGameFor(2f));

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
            bool correctIngredientClicked;
            if (ingredientComponent.Ingredient == Ingredients[_currentCakeStep])
            {
                correctIngredientClicked = true;
                _currentCakeStep++;
                StartCoroutine(PlayCorrectIngredientFx());
                if (IsMiniGameFinished())
                {
                    StartCoroutine(NpcAnimationController.SetFinishedSprite());
                    CloseMiniGame();
                    return;
                }

                StartCoroutine(UiController.SetSpeechBubbleText(_currentCakeStep));
            }
            else
            {
                correctIngredientClicked = false;
                WrongSfx.Play();
            }

            if (!NpcAnimationController.Initialized)
            {
                // Initialize the first Npc expression through the default Npc sprite.
                StartCoroutine(NpcAnimationController.InitNpcExpression(correctIngredientClicked));
                return;
            }

            NpcAnimationController.ChangeNpcExpression(correctIngredientClicked);
        }

        /// <summary>
        /// Shuts down all playable components of the mini game
        /// and rewards the player with an achievement.
        /// </summary>
        private void CloseMiniGame()
        {
            StartCoroutine(UiController.MiniGameFinished(2f));
            UnsubscribeFromExternalEvents();
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
