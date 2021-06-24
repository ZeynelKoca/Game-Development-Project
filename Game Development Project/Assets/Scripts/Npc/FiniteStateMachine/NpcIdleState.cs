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
            _npcTrigger.Npc.InteractButton.SetActive(false);

            if (_npcTrigger.Npc.Interactable)
            {
                return _npcTrigger.NpcInteractableState;
            }

            return _npcTrigger.NpcIdleState;
        }
    }
}
