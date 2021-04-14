namespace Assets.Scripts.Npc.States
{
    public class NpcIdleState : INpcState
    {
        private NpcTrigger _npcTrigger;

        public NpcIdleState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            throw new System.NotImplementedException();
        }
    }
}
