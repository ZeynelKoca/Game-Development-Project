using System;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Npc.FiniteStateMachine
{
    public class NpcCompletedState : INpcState
    {
        public bool TransitionedFromMiniGame { get; set; }

        private readonly NpcTrigger _npcTrigger;

        private bool _triggerDataInitialized;
        private bool _gameStateRestored;

        public NpcCompletedState(NpcTrigger npcTrigger)
        {
            _npcTrigger = npcTrigger;
        }

        public INpcState ExecuteState()
        {
            if (TransitionedFromMiniGame)
            {
                InitTriggerData();

                if (_npcTrigger.TriggerInteracted && !PauseMenuController.GamePausedState && Input.anyKeyDown)
                {
                    if (!Input.GetKeyDown(KeyCode.P) && !Input.GetKeyDown(KeyCode.Escape))
                    {
                        _npcTrigger.Npc.DisplayDialogSentence();

                        if (_npcTrigger.Npc.DialogDone)
                        {
                            AssignAchievement();
                            return _npcTrigger.NpcIdleState;
                        }
                    }
                }
                return _npcTrigger.NpcCompletedState;
            }

            AssignAchievement();
            return _npcTrigger.NpcIdleState;
        }

        /// <summary>
        /// Initializes the proper variables for the game before executing
        /// the actual state's action.
        /// </summary>
        private void InitTriggerData()
        {
            if (!_triggerDataInitialized)
            {
                _npcTrigger.Npc.InteractButton.SetActive(false);
                _npcTrigger.Npc.UiText.enabled = true;
                _npcTrigger.TriggerInteracted = true;
                _npcTrigger.Npc.Camera.enabled = true;
                _npcTrigger.NpcFacePlayer.FaceDirection(_npcTrigger.Npc.Camera.transform);
                _npcTrigger.Npc.StartMiniGameAchievedDialog();
                Time.timeScale = 0f;
                _triggerDataInitialized = true;
            }
        }

        /// <summary>
        /// Assigns the proper achievement to the player according to
        /// the current NPCs type.
        /// </summary>
        private void AssignAchievement()
        {
            _npcTrigger.Npc.StartAchievementBadgeAnimation();

            switch (_npcTrigger.Npc.NpcType)
            {
                case NpcType.Panda:
                    if (!AchievementsManager.Instance.PandaAchieved)
                    {
                        AchievementsManager.Instance.PandaAchieved = true;
                    }
                    break;
                case NpcType.Bear:
                    if (!AchievementsManager.Instance.BearAchieved)
                    {
                        AchievementsManager.Instance.BearAchieved = true;
                    }
                    break;
                case NpcType.Bird:
                    if (!AchievementsManager.Instance.BirdAchieved)
                    {
                        AchievementsManager.Instance.BirdAchieved = true;
                    }
                    break;
                case NpcType.Dog:
                    if (!AchievementsManager.Instance.DogAchieved)
                    {
                        AchievementsManager.Instance.DogAchieved = true;
                    }
                    break;
                case NpcType.Elephant:
                    if (!AchievementsManager.Instance.ElephantAchieved)
                    {
                        AchievementsManager.Instance.ElephantAchieved = true;
                    }
                    break;
                case NpcType.Monkey:
                    if (!AchievementsManager.Instance.MonkeyAchieved)
                    {
                        AchievementsManager.Instance.MonkeyAchieved = true;
                    }
                    break;
                case NpcType.Penguin:
                    if (!AchievementsManager.Instance.PenguinAchieved)
                    {
                        AchievementsManager.Instance.PenguinAchieved = true;
                    }
                    break;
                case NpcType.Squirrel:
                    if (!AchievementsManager.Instance.SquirrelAchieved)
                    {
                        AchievementsManager.Instance.SquirrelAchieved = true;
                    }
                    break;
                case NpcType.Crocodile:
                    if (!AchievementsManager.Instance.OstrichAchieved)
                    {
                        AchievementsManager.Instance.OstrichAchieved = true;
                    }
                    if (!AchievementsManager.Instance.CrocodileAchieved)
                    {
                        AchievementsManager.Instance.CrocodileAchieved = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            RestoreGameState();
        }

        /// <summary>
        /// Initializes the proper world variables before
        /// resuming the game.
        /// </summary>
        private void RestoreGameState()
        {
            if (!_gameStateRestored)
            {
                ActivateNextNpc();
                InteractableObject.IsDialogShowing = false;
                _npcTrigger.Npc.Camera.enabled = false;
                _npcTrigger.NpcFacePlayer.IsInteracted = false;
                _npcTrigger.Npc.UiText.enabled = false;
                _npcTrigger.TriggerInteracted = false;
                Time.timeScale = 1f;
                TransitionedFromMiniGame = false;
                _gameStateRestored = true;
            }
        }

        /// <summary>
        /// Activates the interactibility of the next npc
        /// so the player can start working on the next achievement.
        /// </summary>
        private void ActivateNextNpc()
        {
            var npcGameObject = GetNpcGameObject(_npcTrigger.Npc.NextQuestNpcType);
            var npcInteractableObject = npcGameObject.GetComponent<InteractableObject>();
            npcInteractableObject.Interactable = true;
        }

        private GameObject GetNpcGameObject(NpcType npcType)
        {
            switch (npcType)
            {
                case NpcType.Panda:
                    return GameObject.FindGameObjectWithTag("PandaNPC");
                case NpcType.Bear:
                    return GameObject.FindGameObjectWithTag("BearNPC");
                case NpcType.Bird:
                    return GameObject.FindGameObjectWithTag("BirdNPC");
                case NpcType.Dog:
                    return GameObject.FindGameObjectWithTag("DogNPC");
                case NpcType.Elephant:
                    return GameObject.FindGameObjectWithTag("ElephantNPC");
                case NpcType.Monkey:
                    return GameObject.FindGameObjectWithTag("MonkeyNPC");
                case NpcType.Penguin:
                    return GameObject.FindGameObjectWithTag("PenguinNPC");
                case NpcType.Squirrel:
                    return GameObject.FindGameObjectWithTag("SquirrelNPC");
                case NpcType.Crocodile:
                    return GameObject.FindGameObjectWithTag("CrocodileNPC");
                default:
                    throw new ArgumentOutOfRangeException(nameof(npcType), npcType, null);
            }
        }
    }
}