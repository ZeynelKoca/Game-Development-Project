using Assets.Scripts.Npc.FiniteStateMachine;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class NpcTrigger : MonoBehaviour
    {
        public SpriteFacePlayer SpriteFacePlayer;
        public SceneField MiniGameScene;
        public NpcPatrol NpcPatrol;
        public InteractableObject Npc;
        public Text Text;
        public GameObject ExclamationMark;

        #region States

        public INpcState CurrentNpcState;
        public NpcIdleState NpcIdleState;
        public NpcInteractableState NpcInteractableState;
        public NpcInteractedState NpcInteractedState;
        public NpcCompletedState NpcCompletedState;

        #endregion

        public bool GamePaused { get; set; }
        public bool IsTriggerActive { get; private set; }

        private void Start()
        {
            InitStates();
            Npc.Camera.enabled = false;
            GamePaused = false;
            IsTriggerActive = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsTriggerActive = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsTriggerActive = false;
            }
        }

        public void Update()
        {
            if (!IsTriggerActive)
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
            NpcInteractableState = new NpcInteractableState(this);
            NpcInteractedState = new NpcInteractedState(this);
            NpcCompletedState = new NpcCompletedState(this);

            // Start the npc off with the idle state.
            CurrentNpcState = NpcIdleState;
        }
    }
}
