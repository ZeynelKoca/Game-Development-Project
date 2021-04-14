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

            if (_npcTrigger.GamePaused && Input.GetKeyDown(KeyCode.E))
            {
                _npcTrigger.Npc.Talk(_npcTrigger.Text);
                
                if (_npcTrigger.Npc.DialogDone)
                {
                    return _npcTrigger.NpcCompletedState;
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
                _npcTrigger.Text.enabled = true;
                _npcTrigger.GamePaused = true;
                _npcTrigger.Npc.Camera.enabled = true;
                _player.transform.position = _npcTrigger.CalculateNewPlayerPosition();
                _npcTrigger.NpcPatrol.FaceDirection(_player.transform.position);
                _npcTrigger.Npc.InitDialog(_npcTrigger.Text);
                Time.timeScale = 0f;
                Interacted = true;
            }
        }
    }
}
