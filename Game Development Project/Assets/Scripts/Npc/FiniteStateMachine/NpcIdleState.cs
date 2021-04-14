using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcIdleState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;

        public NpcIdleState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            if (_npcTrigger.IsTriggerActive && !_npcTrigger.GamePaused)
            {
                _npcTrigger.Text.text = "Press E to interact";
                _npcTrigger.Text.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    return _npcTrigger.NpcInteractedState;
                }
            }

            return _npcTrigger.NpcIdleState;
        }
    }
}
