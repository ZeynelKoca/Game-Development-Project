using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcCompletedState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;

        public NpcCompletedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            // TODO: Set next NPC (InteractableObject.Interactable) to True.

            _npcTrigger.ExclamationMark.SetActive(false);
            AssignAchievement();

            return _npcTrigger.NpcCompletedState;
        }

        private void AssignAchievement()
        {
            switch (_npcTrigger.Npc.NpcType)
            {
                case NpcType.Panda:
                    if (!AchievementsManager.Instance.PandaAchieved)
                    {
                        AchievementsManager.Instance.PandaAchieved = true;
                        RestoreGameState();
                    }
                    break;
            }
        }

        /// <summary>
        /// Initializes the proper world variables before
        /// resuming the game.
        /// </summary>
        private void RestoreGameState()
        {
            InteractableObject.IsDialogShowing = false;
            _npcTrigger.Npc.Camera.enabled = false;
            _npcTrigger.Text.enabled = false;
            _npcTrigger.GamePaused = false;
            Time.timeScale = 1f;
        }
    }
}
