using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class InteractableObject : MonoBehaviour
    {
        public static bool IsDialogShowing;

        public Camera Camera;
        public Vector3 PlayerPositionOffset;
        public GameObject Object;
        public string[] DialogText;

        private int _currentDialogIndex;
        private bool _dialogInitialized;

        public bool DialogDone { get; private set; }

        /// <summary>
        /// Sets the proper sentence(s) on the specified Text UI.
        /// </summary>
        /// <param name="text">The Text object.</param>
        public void Talk(Text text)
        {
            _currentDialogIndex++;
            DialogDone = _currentDialogIndex == DialogText.Length;

            if (DialogDone)
            {
                IsDialogShowing = false;
                _dialogInitialized = false;
                return;
            }
            
            text.text = DialogText[_currentDialogIndex];
        }

        /// <summary>
        /// Initializes the proper variables in order to start the dialog
        /// of the current object and displays the first dialog text.
        /// </summary>
        public void InitDialog(Text text)
        {
            if (!_dialogInitialized)
            {
                DialogDone = false;
                IsDialogShowing = true;
                _currentDialogIndex = - 1;
                _dialogInitialized = true;
                Talk(text);
            }
        }
    }
}
