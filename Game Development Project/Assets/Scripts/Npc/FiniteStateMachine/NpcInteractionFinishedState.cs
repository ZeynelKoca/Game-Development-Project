using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcInteractionFinishedState : INpcState
    {
        private readonly NpcTrigger _npcTrigger;

        public NpcInteractionFinishedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            _npcTrigger.ExclamationMark.SetActive(false);

            if (_npcTrigger.MiniGameScene.SceneAsset != null)
            {
                NavigateMiniGameScene();
            }

            return _npcTrigger.NpcCompletedState;
        }

        /// <summary>
        /// Saves the necessary scene data into <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void SaveSceneChangeData()
        {
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            SceneChangeSaveData.MainCharacterPosition = playerGameObject.transform.position;
            SceneChangeSaveData.MainCharacterRotation = playerGameObject.transform.rotation;

            var npcTransform = _npcTrigger.Npc.transform.parent;
            SceneChangeSaveData.NpcPosition = npcTransform.position;
            SceneChangeSaveData.InteractedNpcType = _npcTrigger.Npc.NpcType;
        }

        /// <summary>
        /// Loads the NPCs mini-game scene.
        /// </summary>
        public void NavigateMiniGameScene()
        {
            SaveSceneChangeData();
            InteractableObject.IsDialogShowing = false;
            // Game is not in paused state when in the main menu, but you still want to be able to use the Cursor.
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(_npcTrigger.MiniGameScene);
        }
    }
}
