namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public interface INpcState
    {
        /// <summary>
        /// Executes the activity associated with the current state 
        /// </summary>
        /// <returns>The next state to be transitioned to.</returns>
        /// <remarks>Can return itself as the next state, which means 
        /// there's no transition to another state.</remarks>
        INpcState ExecuteState();
    }
}
