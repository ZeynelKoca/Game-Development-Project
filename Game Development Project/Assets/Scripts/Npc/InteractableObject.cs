using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class InteractableObject : MonoBehaviour
    {
        public static bool IsDialogShowing;

        public NpcType NpcType;
        public NpcType NextQuestNpcType;
        public Camera Camera;
        public GameObject InteractText;
        public Text UiText;
        public string[] DialogText;
        public string[] MiniGameAchievedText;

        private string[] _currentDialogText;
        private int _currentDialogIndex;
        private bool _dialogInitialized;

        public bool Interactable { get; set; }
        public bool DialogDone { get; private set; }

        /// <summary>
        /// Sets the proper sentence(s) of the dialog on the UI Text.
        /// </summary>
        public void DisplayDialogSentence()
        {
            _currentDialogIndex++;
            DialogDone = _currentDialogIndex == _currentDialogText.Length;

            if (DialogDone)
            {
                IsDialogShowing = false;
                _dialogInitialized = false;
                return;
            }

            UiText.text = _currentDialogText[_currentDialogIndex];
        }

        /// <summary>
        /// Initializes the proper variables in order to start the dialog
        /// of the current object and displays the first dialog text.
        /// </summary>
        public void InitInitialDialog()
        {
            if (!_dialogInitialized)
            {
                _currentDialogText = DialogText;
                _currentDialogIndex = -1;
                _dialogInitialized = true;
                DialogDone = false;
                IsDialogShowing = true;
                DisplayDialogSentence();
            }
        }

        /// <summary>
        /// Initializes the proper variables in order to start the dialog
        /// of the current object and displays the first dialog text.
        /// </summary>
        public void InitMiniGameAchievedDialog()
        {
            if (!_dialogInitialized)
            {
                _currentDialogText = MiniGameAchievedText;
                _currentDialogIndex = -1;
                _dialogInitialized = true;
                DialogDone = false;
                IsDialogShowing = true;
                if (_currentDialogText.Length > 0)
                {
                    DisplayDialogSentence();
                }
            }
        }
    }
}
