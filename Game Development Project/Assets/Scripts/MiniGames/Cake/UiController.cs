using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGames.Cake
{
    public class UiController : MonoBehaviour
    {
        public Button[] IngredientButtons;
        public string[] SpeechBubbleDialogue;
        public TextMeshPro SpeechBubbleText;
        public RawImage SpeechBubbleImage;
        public GameObject FinishedPanel;
        public GameObject FinishedButtonParticle;

        /// <summary>
        /// Disables the mini game for the specified amount of seconds.
        /// </summary>
        /// <param name="seconds">The amount of seconds to be disabled for.</param>
        public IEnumerator DisableMiniGameFor(float seconds)
        {
            DisableMiniGame();

            // After waiting for the specified amount of seconds, re-enables everything again.
            yield return new WaitForSeconds(seconds);
            SpeechBubbleImage.enabled = true;
            SpeechBubbleText.SetText(SpeechBubbleDialogue[0]);
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
            SpeechBubbleText.SetText("");
            foreach (var button in IngredientButtons)
            {
                button.interactable = false;
            }
        }

        /// <summary>
        /// Sets the proper text on the speech bubble of the NPC.
        /// </summary>
        public IEnumerator SetSpeechBubbleText(int textIndex)
        {
            // Clear the speech bubble first.
            SpeechBubbleImage.enabled = false;
            SpeechBubbleText.SetText("");
            yield return new WaitForSeconds(0.3f);
            SpeechBubbleImage.enabled = true;
            SpeechBubbleText.SetText(SpeechBubbleDialogue[textIndex]);
        }

        /// <summary>
        /// Disables the interactable components of the mini game and after
        /// waiting for the specified amount of seconds, enables the finished button.
        /// </summary>
        /// <param name="seconds">The amount of seconds to wait before enabling the finished button.</param>
        public IEnumerator MiniGameFinished(float seconds)
        {
            DisableMiniGame();
            yield return new WaitForSeconds(seconds);
            ShowFinishedPanel();
        }

        /// <summary>
        /// Enables the visibility of the finished panel in the Ui.
        /// </summary>
        private void ShowFinishedPanel()
        {
            FinishedPanel.SetActive(true);
            FinishedButtonParticle.SetActive(true);
        }
    }
}
