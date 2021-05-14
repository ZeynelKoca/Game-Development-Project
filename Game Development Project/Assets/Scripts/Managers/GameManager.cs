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
            if (SceneChangeSaveData.MainCharacterPosition != null)
            {
                // Position
                InitMainCharacterPosition();
            }
            if (SceneChangeSaveData.MainCharacterRotation != null)
            {
                // Rotation
                InitMainCharacterRotation();
            }
        }

        /// <summary>
        /// Initializes the Main Character's position according to
        /// the saved position values in <see cref="SceneChangeSaveData"/>.
        /// </summary>
        private void InitMainCharacterPosition()
        {
            var savedPosition = SceneChangeSaveData.MainCharacterPosition;
            System.Diagnostics.Debug.Assert(savedPosition != null);
            var playerGameObject = GameObject.FindGameObjectWithTag("Player");
            playerGameObject.transform.position = (Vector3)savedPosition;
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
        /// Initializes the proper variables and states for
        /// all the NPCs in the game.
        /// </summary>
        private void InitNpcs()
        {
            if (!AchievementsManager.Instance.PandaAchieved)
            {
                var panda = GameObject.FindGameObjectWithTag("PandaNPC");
                ActivateNpc(panda);
            }
            // TODO: else if statements for every other npc in the game in order of activation.
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
