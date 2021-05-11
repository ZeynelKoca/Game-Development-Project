using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cake
{
    public class CakeManager : MonoBehaviour
    {
        public Ingredient[] Ingredients;
        public ParticleSystem ParticleSystem;
        public AudioSource CorrectSfx;
        public AudioSource WrongSfx;

        private int _currentCakeStep;

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
                StartCoroutine(PlayCorrectIngredientFx());
                _currentCakeStep++;
            }
            else
            {
                // Wrong ingredient has been clicked.
                WrongSfx.Play();
            }
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
    }
}
