using Assets.Scripts.Npc.FiniteStateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class NpcTrigger : MonoBehaviour
    {
        public NpcPatrol NpcPatrol;
        public InteractableObject Npc;
        public Text Text;
        public GameObject ExclamationMark;

        private bool _triggerActive;

        #region States

        public INpcState CurrentNpcState;
        public NpcIdleState NpcIdleState;
        public NpcInteractedState NpcInteractedState;
        public NpcCompletedState NpcCompletedState;

        #endregion

        public bool GamePaused { get; set; }
        public bool IsTriggerActive => _triggerActive;

        private void Start()
        {
            InitStates();
            Npc.Camera.enabled = false;
            GamePaused = false;
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
            if (NpcCompletedState.Completed)
            {
                ExclamationMark.SetActive(false);
            }
            if (!_triggerActive)
            {
                Text.enabled = false;
            }
            
            // Execute the current state action and store the upcoming (transition) state to be called in the next Update loop.
            CurrentNpcState = CurrentNpcState.ExecuteState();
        }

        /// <summary>
        /// Initializes the npc states and sets the initial state of the npc.
        /// </summary>
        private void InitStates()
        {
            NpcIdleState = new NpcIdleState(this);
            NpcInteractedState = new NpcInteractedState(this);
            NpcCompletedState = new NpcCompletedState(this);

            // Start the npc off with the idle state.
            CurrentNpcState = NpcIdleState;
        }

        /// <summary>
        /// Calculates the new player position according to the location
        /// of the npc and the set player position offset.
        /// </summary>
        /// <returns></returns>
        public Vector3 CalculateNewPlayerPosition()
        {
            return Npc.Object.transform.position + Npc.PlayerPositionOffset;
        }
    }
}
