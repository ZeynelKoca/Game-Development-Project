using System;
using Assets.Scripts.Npc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        void Awake()
        {
            CreateSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {
            SubscribeToExternalEvents();
        }
        
        /// <summary>
        /// Ensures that only one instance is made of this gameObject.
        /// </summary>
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Subscribes to external events.
        /// </summary>
        private void SubscribeToExternalEvents()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene scene)
        {
            if (scene.name == "SampleScene")
            {
                InitNpcs();
                InitMainCharacterTransform();
            }
        }

        /// <summary>
        /// Checks whether the Main Character's transform values
        /// were saved and if so, initializes it with these saved values.
        /// </summary>
        /// <remarks>
        /// This can be used to initialize the character's position after a mini game scene.
        /// </remarks>
        private void InitMainCharacterTransform()
        {
            if (SceneChangeSaveData.MainCharacterPosition != null && SceneChangeSaveData.NpcPosition != null)
            {
                // Position
                InitSceneSaveData();
            }
            if (SceneChangeSaveData.MainCharacterRotation != null)
            {
                // Rotation
                InitMainCharacterRotation();
            }
        }

        /// <summary>
        /// Initializes the proper save data values according to
        /// <see cref="SceneChangeSaveData"/> for the specified Npc.
        /// </summary>
        /// <param name="npcInteractable">The Npc GameObject to be initialized.</param>
        private void InitNpcSaveData(GameObject npcInteractable)
        {
            // Npc position
            System.Diagnostics.Debug.Assert(SceneChangeSaveData.NpcPosition != null);
            npcInteractable.transform.parent.position = (Vector3)SceneChangeSaveData.NpcPosition;

            // Npc state
            var npcTrigger = npcInteractable.transform.Find("TriggerBox").GetComponent<NpcTrigger>();
            npcTrigger.NpcCompletedState.TransitionedFromMiniGame = true;
            npcTrigger.CurrentNpcState = npcTrigger.NpcCompletedState;
        }

        /// <summary>
        /// Initializes the proper scene data values according to
        /// the saved data in <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void InitSceneSaveData()
        {
            switch (SceneChangeSaveData.InteractedNpcType)
            {
                case NpcType.Panda:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("PandaNPC"));
                    break;
                case NpcType.Bear:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("BearNPC"));
                    break;
                case NpcType.Bird:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("BirdNPC"));
                    break;
                case NpcType.Dog:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("DogNPC"));
                    break;
                case NpcType.Elephant:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("ElephantNPC"));
                    break;
                case NpcType.Monkey:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("MonkeyNPC"));
                    break;
                case NpcType.Penguin:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("PenguinNPC"));
                    break;
                case NpcType.Squirrel:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("SquirrelNPC"));
                    break;
                case NpcType.Crocodile:
                    InitNpcSaveData(GameObject.FindGameObjectWithTag("CrocodileNPC"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            InitMainCharacterPosition();
        }

        /// <summary>
        /// Initializes the Main Character's position according to
        /// the saved position values in <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void InitMainCharacterPosition()
        {
            var savedPlayerPosition = SceneChangeSaveData.MainCharacterPosition;
            System.Diagnostics.Debug.Assert(savedPlayerPosition != null);
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerGameObject.transform.position = (Vector3)savedPlayerPosition;
            SceneChangeSaveData.MainCharacterPosition = null;
        }

        /// <summary>
        /// Initializes the Main Character's rotation according to
        /// the saved rotation values in <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void InitMainCharacterRotation()
        {
            var savedRotation = SceneChangeSaveData.MainCharacterRotation;
            System.Diagnostics.Debug.Assert(savedRotation != null);
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerGameObject.transform.rotation = (Quaternion)savedRotation;
            SceneChangeSaveData.MainCharacterRotation = null;
        }

        /// <summary>
        /// Initializes the proper variables and states for
        /// all the NPCs in the game.
        /// </summary>
        /// <remarks>
        /// Order of achievement checks directly reflects the order of npc interactibility.
        /// </remarks>
        private void InitNpcs()
        {
            if (!AchievementsManager.Instance.PandaAchieved)
            {
                var panda = GameObject.FindGameObjectWithTag("PandaNPC");
                ActivateNpc(panda);
            }
            else if (!AchievementsManager.Instance.BearAchieved)
            {
                var bear = GameObject.FindGameObjectWithTag("BearNPC");
                ActivateNpc(bear);
            }
            else if (!AchievementsManager.Instance.BirdAchieved)
            {
                var bird = GameObject.FindGameObjectWithTag("BirdNPC");
                ActivateNpc(bird);
            }
            else if (!AchievementsManager.Instance.DogAchieved)
            {
                var dog = GameObject.FindGameObjectWithTag("DogNPC");
                ActivateNpc(dog);
            }
            else if (!AchievementsManager.Instance.ElephantAchieved)
            {
                var elephant = GameObject.FindGameObjectWithTag("ElephantNPC");
                ActivateNpc(elephant);
            }
            else if (!AchievementsManager.Instance.MonkeyAchieved)
            {
                var monkey = GameObject.FindGameObjectWithTag("MonkeyNPC");
                ActivateNpc(monkey);
            }
            else if (!AchievementsManager.Instance.PenguinAchieved)
            {
                var penguin = GameObject.FindGameObjectWithTag("PenguinNPC");
                ActivateNpc(penguin);
            }
            else if (!AchievementsManager.Instance.SquirrelAchieved)
            {
                var squirrel = GameObject.FindGameObjectWithTag("SquirrelNPC");
                ActivateNpc(squirrel);
            }
            else if (!AchievementsManager.Instance.CrocodileAchieved)
            {
                var crocodile = GameObject.FindGameObjectWithTag("CrocodileNPC");
                ActivateNpc(crocodile);
            }
        }

        /// <summary>
        /// Activates an NPC by setting its GameObject's
        /// interactibility to <c>true</c>.
        /// </summary>
        /// <param name="npcGameObject"></param>
        private void ActivateNpc(GameObject npcGameObject)
        {
            var interactableObject = npcGameObject.GetComponent<InteractableObject>();
            interactableObject.Interactable = true;
        }
    }
}
