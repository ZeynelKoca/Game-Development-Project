using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class IntractableObject : MonoBehaviour
    {
        public static bool IsDialogShowing;

        public Camera Camera;
        public Vector3 PlayerPosition;
        public GameObject Object;
        public string[] DialogText;

        private int _currentDialogIndex;

        public bool DialogDone { get; private set; }

        /// <summary>
        /// Sets the proper sentence(s) on the specified Text UI.
        /// </summary>
        /// <param name="text">The Text object.</param>
        public void Talk(Text text)
        {
            text.text = DialogText[_currentDialogIndex];
            _currentDialogIndex++;

            DialogDone = _currentDialogIndex == DialogText.Length;

            if (DialogDone)
            {
                IsDialogShowing = false;
            }
        }

        /// <summary>
        /// Initializes the proper variables in order to start the dialog of the current object.
        /// </summary>
        public void InitDialog()
        {
            DialogDone = false;
            IsDialogShowing = true;
            _currentDialogIndex = 0;
        }
    }
}
