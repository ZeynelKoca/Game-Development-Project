﻿using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcInteractableState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;

        public NpcInteractableState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            if (_npcTrigger.Npc.HasActiveQuest())
            {
                _npcTrigger.ExclamationMark.SetActive(true);
            }

            if (_npcTrigger.IsTriggerActive && !_npcTrigger.TriggerInteracted)
            {
                _npcTrigger.Npc.InteractButton.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return _npcTrigger.NpcInteractedState;
                }
            }

            return _npcTrigger.NpcInteractableState;
        }
    }
}
