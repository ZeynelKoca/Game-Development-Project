using System;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SavePlayerTransformData();
            AssignAchievement();
            //NavigateMiniGameScene();

            return _npcTrigger.NpcCompletedState;
        }

        /// <summary>
        /// Saves the player's current transform data into <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void SavePlayerTransformData()
        {
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            SceneChangeSaveData.MainCharacterPosition = playerGameObject.transform.position;
            SceneChangeSaveData.MainCharacterRotation = playerGameObject.transform.rotation;
        }

        /// <summary>
        /// Assigns the proper achievement to the player according to
        /// the current NPCs type.
        /// </summary>
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

        /// <summary>
        /// Loads the NPCs mini-game scene.
        /// </summary>
        //public void NavigateMiniGameScene()
        //{
        //    if (_npcTrigger.MiniGameScene.SceneName != String.Empty)
        //    {
        //        InteractableObject.IsDialogShowing = false;
        //        // Game is not in paused state when in the main menu, but you still want to be able to use the Cursor.
        //        Cursor.visible = true;
        //        Cursor.lockState = CursorLockMode.None;
        //        SceneManager.LoadScene(_npcTrigger.MiniGameScene);
        //    }
        //}
    }
}
