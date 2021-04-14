namespace Assets.Scripts.Npc.States
{
    public class NpcCompletedState : INpcState
    {
        private NpcTrigger _npcTrigger;

        public NpcCompletedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            throw new System.NotImplementedException();
        }
    }
}
