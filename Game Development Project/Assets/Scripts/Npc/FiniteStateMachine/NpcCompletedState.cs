using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcCompletedState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;

        public bool Completed { get; private set; }

        public NpcCompletedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            InitTriggerData();
            return _npcTrigger.NpcCompletedState;
        }

        /// <summary>
        /// Initializes the proper variables for the game before executing
        /// the actual state's action.
        /// </summary>
        private void InitTriggerData()
        {
            // Change this private boolean check into a check for player achievements.
            if (!Completed)
            {
                InteractableObject.IsDialogShowing = false;
                _npcTrigger.Npc.Camera.enabled = false;
                _npcTrigger.Text.enabled = false;
                _npcTrigger.GamePaused = false;
                Time.timeScale = 1f;
                Completed = true;
            }
        }
    }
}
