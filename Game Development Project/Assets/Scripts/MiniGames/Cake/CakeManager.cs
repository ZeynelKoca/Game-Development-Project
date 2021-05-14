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

        private int _currentCakeStep;
        private const int TotalCakeSteps = 9;

        void Awake()
        {
            // TODO: Add voice over audio and change # seconds according to the audio duration.
            StartCoroutine(UiController.DisableMiniGameFor(4f));
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
                    StartCoroutine(UiController.MiniGameFinished(2f));
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
