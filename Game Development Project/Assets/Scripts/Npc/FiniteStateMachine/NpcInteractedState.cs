using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcInteractedState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;
        private readonly GameObject _player;

        public bool Interacted { get; private set; }

        public NpcInteractedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public INpcState ExecuteState()
        {
            InitTriggerData();

            if (_npcTrigger.TriggerInteracted && !PauseMenuController.GamePausedState && Input.anyKeyDown)
            {
                if (!Input.GetKeyDown(KeyCode.P) && !Input.GetKeyDown(KeyCode.Escape))
                {
                    _npcTrigger.Npc.DisplayDialogSentence();

                    if (_npcTrigger.Npc.DialogDone)
                    {
                        Interacted = false;
                        return _npcTrigger.NpcInteractionFinishedState;
                    }
                }
            }

            return _npcTrigger.NpcInteractedState;
        }

        /// <summary>
        /// Initializes the proper variables for the game before executing
        /// the actual state's action.
        /// </summary>
        private void InitTriggerData()
        {
            if (!Interacted)
            {
                _npcTrigger.Npc.InteractButton.SetActive(false);
                _npcTrigger.Npc.UiText.enabled = true;
                _npcTrigger.TriggerInteracted = true;
                _npcTrigger.Npc.Camera.enabled = true;
                var playerMovement = _player.GetComponent<PlayerMovementController>();
                playerMovement.FaceDirection(_npcTrigger.NpcPatrol.transform.position);
                _npcTrigger.NpcFacePlayer.FaceDirection(_npcTrigger.Npc.Camera.transform);

                if (_npcTrigger.Npc.HasActiveQuest())
                {
                    _npcTrigger.Npc.StartInitialDialog();
                }
                else
                {
                    _npcTrigger.Npc.StartFinishedDialog();
                }

                Time.timeScale = 0f;
                Interacted = true;
            }
        }
    }
}
