using Assets.Scripts.Npc.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class NpcTrigger : MonoBehaviour
    {
        public NpcPatrol NpcPatrol;
        public InteractableObject Npc;
        public Text Text;
        private GameObject _player;
        private bool _gamePaused;
        private bool _triggerActive;

        #region States

        public INpcState CurrentNpcState;
        public NpcIdleState NpcIdleState;

        #endregion

        public bool IsTriggerActive => _triggerActive;
        public bool IsGamePaused => _gamePaused;

        private void Start()
        {
            InitStates();
            _player = GameObject.FindGameObjectWithTag("Player");
            Npc.Camera.enabled = false;
            _gamePaused = false;
            _triggerActive = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _triggerActive = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _triggerActive = false;
            }
        }

        public void Update()
        {
            if (_triggerActive && !_gamePaused)
            {
                Text.text = "Press E to interact";
                Text.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Text.enabled = true;
                    _gamePaused = true;
                    Npc.Camera.enabled = true;
                    SetPlayerPositionToNpcOffset();
                    NpcPatrol.FaceDirection(_player.transform.position);
                    Npc.InitDialog();
                    Time.timeScale = 0f;
                }
            }

            if (_gamePaused && Input.GetKeyDown(KeyCode.E))
            {
                if (!Npc.DialogDone)
                {
                    Npc.Talk(Text);
                }
                else
                {
                    InteractableObject.IsDialogShowing = false;
                    Npc.Camera.enabled = false;
                    Text.enabled = false;
                    _gamePaused = false;
                    Time.timeScale = 1f;
                }
            }

            if (!_triggerActive)
            {
                Text.enabled = false;
            }
        }

        /// <summary>
        /// Initializes the npc states and sets the initial state of the npc.
        /// </summary>
        private void InitStates()
        {
            NpcIdleState = new NpcIdleState(this);

            // Start the npc off with the idle state.
            CurrentNpcState = NpcIdleState;
        }

        /// <summary>
        /// Calculates the offset from the location of the npc to that of the player
        /// and sets the calculated position to the transform of the player.
        /// </summary>
        public void SetPlayerPositionToNpcOffset()
        {
            _player.transform.position = Npc.Object.transform.position + Npc.PlayerPosition;
        }
    }
}
