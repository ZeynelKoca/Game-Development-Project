using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Cake
{
    public class CakeManager : MonoBehaviour
    {
        public Ingredient[] Ingredients;
        public Button[] IngredientButtons;
        public string[] SpeechBubbleText;
        public TextMeshPro SpeechBubble;
        public RawImage SpeechBubbleImage;
        public ParticleSystem ParticleSystem;
        public AudioSource CorrectSfx;
        public AudioSource WrongSfx;

        private int _currentCakeStep;
        private const int TotalCakeSteps = 9;

        void Awake()
        {
            StartCoroutine(DisableMiniGameFor(4f));
        }

        /// <summary>
        /// Disables the mini game for the specified amount of seconds.
        /// </summary>
        /// <param name="seconds">The amount of seconds to be disabled for.</param>
        private IEnumerator DisableMiniGameFor(float seconds)
        {
            DisableMiniGame();

            // After waiting for the specified amount of seconds, re-enables everything again.
            yield return new WaitForSeconds(seconds);
            SpeechBubbleImage.enabled = true;
            SpeechBubble.SetText(SpeechBubbleText[_currentCakeStep]);
            foreach (var button in IngredientButtons)
            {
                button.interactable = true;
            }
        }

        /// <summary>
        /// Disables the playable components of the mini game.
        /// </summary>
        private void DisableMiniGame()
        {
            SpeechBubbleImage.enabled = false;
            SpeechBubble.SetText("");
            foreach (var button in IngredientButtons)
            {
                button.interactable = false;
            }
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
                    DisableMiniGame();
                    return;
                }

                StartCoroutine(SetSpeechBubbleText(_currentCakeStep));
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
        /// Sets the proper text on the speech bubble of the NPC.
        /// </summary>
        private IEnumerator SetSpeechBubbleText(int textIndex)
        {
            // Clear the speech bubble first.
            SpeechBubbleImage.enabled = false;
            SpeechBubble.SetText("");
            yield return new WaitForSeconds(0.3f);
            SpeechBubbleImage.enabled = true;
            SpeechBubble.SetText(SpeechBubbleText[textIndex]);
        }
    }
}
