namespace Assets.Scripts.Npc.States
{
    public class NpcInteractedState : INpcState
    {
        private NpcTrigger _npcTrigger;

        public NpcInteractedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            throw new System.NotImplementedException();
        }
    }
}
